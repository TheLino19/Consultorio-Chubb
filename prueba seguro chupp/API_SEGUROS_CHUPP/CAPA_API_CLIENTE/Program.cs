
using CAPA_APLICACION.Servicios.Cliente;
using CAPA_APLICACION.Servicios.Excel;
using CAPA_APLICACION.Servicios.Seguros;
using CAPA_APLICACION.Servicios.Validacion;
using CAPA_INFRASTRUCTURAS.Persitencia.Configuracion;
using CAPA_INFRASTRUCTURAS.Repositorio.Clientes;
using CAPA_INFRASTRUCTURAS.Repositorio.Validacion;
using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Agregar acceso a appsettings.json y la configuración de la cadena de conexión
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
// Agregar tu servicio de base de datos a la inyección de dependencias
//builder.Services.AddTransient<SqlConnectionFactory>();

//Capa infrastructura
builder.Services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>(); // Para manejar las conexiones a la DB
builder.Services.AddTransient<IClienteRepository, ClienteRepository>(); // Registro del repositorio
builder.Services.AddTransient<IValidacionRepository, ValidacionRepository>(); // Registro del repositorio

//Capa Aplicacion
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IExcelService, ExcelService>();
builder.Services.AddTransient<IValidacionService, ValidacionService>();
builder.Services.AddTransient<ISegurosService, SeguroService>();

//Capa Utilidades
//builder.Services.AddSingleton<MensajesDeError>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Agrega CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("*")
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();
// Configurar CORS
app.UseCors("AllowSpecificOrigin"); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
