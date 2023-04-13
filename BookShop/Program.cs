
using Domain;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Services.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
     .AddFluentValidation(options =>
     {
         // Validate child properties and root collection elements
         options.ImplicitlyValidateChildProperties = true;

         // Automatic registration of validators in assembly
         options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         
     }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBookModule();
builder.Services.AddDbContext<BooksDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration["ConnectionString"],
                    b => b.MigrationsAssembly(typeof(BooksDBContext).Assembly.FullName)));
builder.Services.AddDbContext<BooksDBContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
