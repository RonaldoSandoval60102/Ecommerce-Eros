using Azure.Messaging.ServiceBus;
using Eros.src.DB;
using Eros.src.Domain.Address.Repository;
using Eros.src.Domain.Address.Services;
using Eros.src.Domain.AuditLog.Repository;
using Eros.src.Domain.AuditLog.Services;
using Eros.src.Domain.Cart.Repository;
using Eros.src.Domain.Cart.Services;
using Eros.src.Domain.Category.Repository;
using Eros.src.Domain.Category.Services;
using Eros.src.Domain.Order.Repository;
using Eros.src.Domain.Order.Services;
using Eros.src.Domain.OrderDetail.Repository;
using Eros.src.Domain.OrderDetail.Services;
using Eros.src.Domain.OrderStatus.Repository;
using Eros.src.Domain.OrderStatus.Services;
using Eros.src.Domain.PaymentMethod.Repository;
using Eros.src.Domain.PaymentMethod.Services;
using Eros.src.Domain.PaymentTransaction.Repository;
using Eros.src.Domain.PaymentTransaction.Services;
using Eros.src.Domain.Product.Repository;
using Eros.src.Domain.Product.Services;
using Eros.src.Domain.User.Repository;
using Eros.src.Domain.User.Services;
using Eros.src.Event;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// service
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentMethodService, PaymentMethodService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IAuditLogService, AuditLogService>();
builder.Services.AddScoped<IPaymentTransactionService, PaymentTransactionService>();
// repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IAuditLogRepository, AuditLogRepository>();
builder.Services.AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>();

// EVent Bus
builder.Services.AddScoped<EventSender>();

builder.Services.AddSingleton<List<ServiceBusHandler>>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();

    var add_Cart = new ServiceBusHandler(configuration, "add_cart");
    var delete_Cart = new ServiceBusHandler(configuration, "delete_cart");
    var update_Cart = new ServiceBusHandler(configuration, "update_cart");

    return new List<ServiceBusHandler>
    {
        add_Cart,
        delete_Cart,
        update_Cart,
    };
});

builder.Services.AddSingleton(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var connectionString = configuration.GetSection("ServiceBusSettings:ConnectionString").Value;
    return new ServiceBusClient(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.Services.GetRequiredService<List<ServiceBusHandler>>().ForEach(async handler =>
{
    await handler.StartProcessingAsync();
});

app.UseCors(builder =>
{
    builder
        .WithOrigins("http://localhost:5173")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStopping.Register(async () =>
{
    var serviceBusHandlers = app.Services.GetRequiredService<List<ServiceBusHandler>>();

    await Task.WhenAll(serviceBusHandlers.Select(async handler =>
    {
        await handler.StopProcessingAsync();
        await handler.DisposeAsync();
    }));
});

await app.RunAsync();