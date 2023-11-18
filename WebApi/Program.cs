using ESCore.ESContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext
string mssqlConStr = builder.Configuration.GetConnectionString("MsSqlConnStr");
//builder.Services.AddPooledDbContextFactory<ESDBContext>((context) => context.UseSqlServer(mssqlConStr));
//builder.Services.AddDbContextPool<ESDBContext>((option) =>option.UseSqlServer(mssqlConStr));
//builder.Services.AddEntityFrameworkSqlServer();
//builder.Services.AddDbContextPool<ESCore.ESContext.ProductContext>(options => options.UseSqlServer(mssqlConStr));
//builder.Services.AddDbContextPool<ESCore.ESContext.ProductSpecificationMapContext>(options => options.UseSqlServer(mssqlConStr));
//builder.Services.AddDbContextPool<ESCore.ESContext.ProductVariantContext>(options => options.UseSqlServer(mssqlConStr));
//builder.Services.AddDbContextPool<ESCore.ESContext.SpecificationContext>(options => options.UseSqlServer(mssqlConStr));
var a = builder.Services.AddDbContextPool<ESDBContext>(options => options.UseSqlServer(mssqlConStr));
builder.Services.AddSqlServer<ESDBContext>(mssqlConStr);
builder.Services.AddScoped<ESDBContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
