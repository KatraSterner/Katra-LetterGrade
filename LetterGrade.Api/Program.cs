

using LetterGrade.Api.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<GradeCalculatorService>(); // added connection to service -----------
builder.Services.AddControllers(); // added connection to controllers --------------------------

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(); // enable Scalar UI ------------------------------------------
}

app.UseHttpsRedirection();

app.UseAuthorization(); // added for authorization on controllers (not used in this project) --
app.MapControllers(); // map controllers ------------------------------------------------------

// added to allow any website to call this API (NOT SAFE FOR PRODUCTION) ----------------------
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);


app.Run();

