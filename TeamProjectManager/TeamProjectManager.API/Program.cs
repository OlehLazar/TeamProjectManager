using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using TeamProjectManager.API.Middleware;
using TeamProjectManager.API.Validation.User;
using TeamProjectManager.DAL.Data;
using TeamProjectManager.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidationAutoValidation()
				.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<LoginValidator>();

builder.Services.AddDbContext<ManagerDbContext>(options =>
{
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandler>();

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
