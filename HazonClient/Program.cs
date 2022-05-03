using System.Text;
using Hazon.DAL.Domain.Data;
using Hazon.DAL.Domain.Models.AccountViewModels;
using Hazon.DAL.Domain.Models.Configuration;
using Hazon.DAL.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("HazonConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddAuthentication(c =>
{
    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(s =>
{
    var secret = Encoding.UTF8.GetBytes(builder.Configuration["jwtTokenConfig:secret"]);
    s.SaveToken = true;
    s.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["jwtTokenConfig:issuer"],
        ValidAudience = builder.Configuration["jwtTokenConfig:audience"],
        IssuerSigningKey = new SymmetricSecurityKey(secret)
    };
});

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

//builder.Services.Configure<IdentityDefaultOptions>(configuration.GetSection("IdentityDefaultOptions"));
//var identityDefaultOptions = configuration.Get<IdentityDefaultOptions>();

//builder.Services.AddIdentity<User, IdentityRole>(options =>
//{
//    // Password settings
//    options.Password.RequireDigit = identityDefaultOptions.PasswordRequireDigit;
//    options.Password.RequiredLength = identityDefaultOptions.PasswordRequiredLength;
//    options.Password.RequireNonAlphanumeric = identityDefaultOptions.PasswordRequireNonAlphanumeric;
//    options.Password.RequireUppercase = identityDefaultOptions.PasswordRequireUppercase;
//    options.Password.RequireLowercase = identityDefaultOptions.PasswordRequireLowercase;
//    options.Password.RequiredUniqueChars = identityDefaultOptions.PasswordRequiredUniqueChars;

//    // Lockout settings
//    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(identityDefaultOptions.LockoutDefaultLockoutTimeSpanInMinutes);
//    options.Lockout.MaxFailedAccessAttempts = identityDefaultOptions.LockoutMaxFailedAccessAttempts;
//    options.Lockout.AllowedForNewUsers = identityDefaultOptions.LockoutAllowedForNewUsers;

//    // User settings
//    options.User.RequireUniqueEmail = identityDefaultOptions.UserRequireUniqueEmail;

//    // email confirmation require
//    options.SignIn.RequireConfirmedEmail = identityDefaultOptions.SignInRequireConfirmedEmail;
//})
//                .AddEntityFrameworkStores<ApplicationDbContext>()
//                .AddDefaultTokenProviders();

// cookie settings
//builder.Services.ConfigureApplicationCookie(options =>
//{
//    // Cookie settings
//    options.Cookie.HttpOnly = identityDefaultOptions.CookieHttpOnly;
//    options.ExpireTimeSpan = TimeSpan.FromDays(identityDefaultOptions.CookieExpiration);
//    options.LoginPath = identityDefaultOptions.LoginPath; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
//    options.LogoutPath = identityDefaultOptions.LogoutPath; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
//    options.AccessDeniedPath = identityDefaultOptions.AccessDeniedPath; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
//    options.SlidingExpiration = identityDefaultOptions.SlidingExpiration;
//});
builder.Services.AddServiceCollection();
builder.Services.AddControllersWithViews();
//builder.Services.AddRazorPages();
builder.Services.AddMvc();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}").RequireAuthorization();
    //app.UseMvc();
app.Run();
