using Core.Application.Extensions;
using FluentValidation.AspNetCore;
using Infrastructure.Extensions;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("HazonConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseNpgsql(connectionString,e => e.MigrationsAssembly("Migration.PostgreSQL")));



//Multitenant dbcontext
//builder.Services.AddMultitenancy<TenantDbContext, ApplicationDbContext>(builder.Configuration);



//builder.Services.AddServiceCollection();
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAuthentication(c =>
//{
//    c.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    c.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(s =>
//{
//    var secret = Encoding.UTF8.GetBytes(builder.Configuration["jwtTokenConfig:secret"]);
//    s.SaveToken = true;
//    s.TokenValidationParameters = new TokenValidationParameters()
//    {
//        ValidateIssuer = false,
//        ValidateAudience = false,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["jwtTokenConfig:issuer"],
//        ValidAudience = builder.Configuration["jwtTokenConfig:audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(secret)
//    };
//});
//

//builder.Build().UseInfrastructure(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

