using BasketIQ.API.Services.CompanyData;
using BasketIQ.API.Interfaces.CompanyData;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProjectInterface, ProjectService>();

builder.Services.AddScoped<IDepartmentInterface, DepartmentService>();

builder.Services.AddScoped<IEmployeeInterface, EmployeeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
