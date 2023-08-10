using BaseProject.Data;
using BaseProject.Data.Service;
using BaseProject.Hubs;
using BaseProject.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// SignalR �̹��� ������ ����
//builder.Services.AddSignalR(options => options.MaximumReceiveMessageSize = 1024 * 1024 * 1024);

// Service Interfase �߰�
//builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IMateralService, MateralService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryServeice>();
builder.Services.AddScoped<IOrderService, OrderService>();


// ������ ����
// builder.Services.AddScoped(sc => OrderController.GetShoppingCart(sc));

// DB ����
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BaseProject.Data.BaseDbContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection))
    );

// ���� ����
builder.Services.AddIdentity<UserIdentity, IdentityRole>(
    options => options.SignIn.RequireConfirmedAccount = false
    )
    .AddEntityFrameworkStores<BaseDbContext>()
    .AddDefaultTokenProviders();

// Cookie
//builder.Services.AddAuthentication(
//    CookieAuthenticationDefaults.AuthenticationScheme
//    ).AddCookie(options => {
//        //options.ExpireTimeSpan = TimeSpan.FromMinutes(60)
//        options.SlidingExpiration = true;
//        options.AccessDeniedPath = "/home/accessdenied";
//        options.LoginPath = "/account/login";
//    });

// Cache
builder.Services.AddMemoryCache();
// Session
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
// Session ����
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapHub<IotHub>("/iothub");
app.Run();
