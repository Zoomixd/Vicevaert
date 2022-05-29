using Microsoft.EntityFrameworkCore;
using PedelApp.Application.Contract;
using PedelApp.Application.Contract.Dtos;
using PedelApp.Application.Implementation;
using PedelApp.Application.Infrastructure;
using PedelApp.Domain.DomainServices;
using PedelApp.Infrastructure.DomainServiceImpl;
using PedelApp.Infrastructure.Queries;
using PedelApp.Infrastructure.RepositoriesImpl;
using Vicev�rt.Application.Contract;
using Vicev�rt.Application.Contract.Dtos;
using Vicev�rt.Application.Implementation;
using Vicev�rt.Application.Infrastructure;
using Vicev�rt.Domain.DomainServices;
using Vicev�rt.Infrastructure.Database;
using Vicev�rt.Infrastructure.DomainServicesImpl;
using Vicev�rt.Infrastructure.Queries;
using Vicev�rt.Infrastructure.RepositoriesImpl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseContext"), x =>
    {
        x.MigrationsAssembly("Vicev�rt.Web");
    }));



builder.Services.AddScoped<IRekvisitionQuery, RekvisitionQuery>();
builder.Services.AddScoped<IRekvisitionCommand, RekvisitionCommand>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();
builder.Services.AddScoped<IRekvisitionRepository, RekvisitionRepository>();
builder.Services.AddScoped<IRekvisitionDomainServices, RekvisitionDomainService>();
builder.Services.AddScoped<ILejemaalQuery, LejemaalQuery>();
//builder.Services.AddScoped<ILejemaalCommand, LejemaalCommand>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();
builder.Services.AddScoped<ILejemaalRepository, LejemaalRepository>();
builder.Services.AddScoped<ILejemaalDomainService, LejemaalDomainService>();
//builder.Services.AddScoped<IBookingQuery, BookingQuery>();
builder.Services.AddScoped<IBookingCommand, BookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
//builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

builder.Services.AddControllers();
builder.Services.AddScoped<ITidsRegistreringQuery, TidsRegistreringQuery>();
builder.Services.AddScoped<ITidsRegistreringCommand, TidsRegistreringCommand>();
builder.Services.AddScoped<ITidsRegistreringRepository, TidsRegistreringRepository>();
builder.Services.AddScoped<ITidsRegistreringDomainService, TidsRegistreringDomainService>();






builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();
