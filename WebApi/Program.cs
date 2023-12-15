using ESCore.ESContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using WebApi.Models.Token;
using System.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using ESService.Abstracts;
using ESService.Bussines;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string mssqlConStr = builder.Configuration.GetConnectionString("MsSqlConnStr");
builder.Services.AddDbContextPool<ESDBContext>(options => options.UseSqlServer(mssqlConStr));
//builder.Services.AddDbContextPool<ESIdentityDbContext>(options => options.UseSqlServer(mssqlConStr));

//builder.Services.AddSqlServer<ESIdentityDbContext>(mssqlConStr);
builder.Services.AddSqlServer<ESDBContext>(mssqlConStr);
builder.Services.AddScoped<ESDBContext>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddIdentity<ESCore.Model.Authentication.User, IdentityRole>()
    .AddEntityFrameworkStores<ESDBContext>()
    .AddDefaultTokenProviders();
builder.Services.AddAuthentication(auth =>
    {
        auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    //.AddScheme<JwtBearerOptions, JwtBearerHandler>(JwtBearerDefaults.AuthenticationScheme, opt =>
    //{
    //    opt.SaveToken = true;
    //    opt.TokenValidationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuer = true,
    //        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
    //        ValidateAudience = true,
    //        ValidAudience = builder.Configuration["JwtSettings:Audience"],
    //        ValidateIssuerSigningKey = true,
    //        ClockSkew = TimeSpan.Zero,
    //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SigningKey"]))
    //    };
    //})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SigningKey"]))
    };
});

//builder.Services.AddSwaggerGen(opt =>
//{
//    opt.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
//    {
//        Name = "Authorization",
//        Type = SecuritySchemeType.Http,
//        Scheme = JwtBearerDefaults.AuthenticationScheme,
//        In = ParameterLocation.Header,
//        BearerFormat = "JWT",
//        Description = "Jwt Authorization header."
//    });
//    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//        new OpenApiSecurityScheme
//        {
//            Reference = new OpenApiReference
//            {
//                Type = ReferenceType.SecurityScheme,
//                Id = JwtBearerDefaults.AuthenticationScheme
//            }
//        }
//        , new string[] {"Beraer"}
//        }
//    });
//});
var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


app.MapControllers();

app.Run();
