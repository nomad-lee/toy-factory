using BaseProject.Data;
using BaseProject.Hubs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// SignalR �̹��� ������ ����
//builder.Services.AddSignalR(options => options.MaximumReceiveMessageSize = 1024 * 1024 * 1024);

// Service Interfase �߰�
//builder.Services.AddScoped<IAccountService, AccountService>();

// ������ ����
// builder.Services.AddScoped(sc => OrderController.GetShoppingCart(sc));

// DB ����
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BaseProject.Data.BaseDbContext>(
    options => options.UseMySql(connection, ServerVersion.AutoDetect(connection))
    );

// ���� ����
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
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
//builder.Services.AddMemoryCache();
// Session
//builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
// Session ����
// app.UseSession();

app.UseAuthorization();
app.UseAuthorization();

AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapHub<IotHub>("/iothub");
app.Run();
