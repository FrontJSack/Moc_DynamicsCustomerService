using Microsoft.EntityFrameworkCore;
using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Services.KontoService;

var builder = WebApplication.CreateBuilder(args);

// Dodajemy połączenie z bazą SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=kontodb.db")); // Baza danych SQLite o nazwie "kontodb.db"


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<KontoService>(); // Dodanie wsparcia dla serwisów API
builder.Services.AddControllers(); // Dodanie wsparcia dla kontrolerów API

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// Reszta konfiguracji aplikacji
app.UseHttpsRedirection(); // Przekierowanie na HTTPS
app.MapControllers(); // Mapowanie kontrolerów do aplikacji

app.Run();
