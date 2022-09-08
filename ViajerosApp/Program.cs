using ViajerosApp.Data;
using ViajerosApp.Extensions;
using ViajerosApp.Repositories;
using ViajerosApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ViajerosDbContext>();

builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<ICiudadRepository, CiudadRepository>();
builder.Services.AddScoped<IViajeRepository, ViajeRepository>();
builder.Services.AddScoped<IViajeroRepository, ViajeroRepository>();

builder.Services.AddScoped<IVehiculoService, VehiculoService>();
builder.Services.AddScoped<ICiudadService, CiudadService>();
builder.Services.AddScoped<IViajeService, ViajeService>();
builder.Services.AddScoped<IViajeroService, ViajeroService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


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

app.MapControllers();

app.Run();
