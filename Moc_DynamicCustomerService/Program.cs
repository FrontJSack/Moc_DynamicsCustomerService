using Moc_DynamicCustomerService.Data;
using Moc_DynamicCustomerService.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Moc_DynamicCustomerService.Services;
using Moc_DynamicCustomerService.Endpoints;


var builder = WebApplication.CreateBuilder(args);

// Dodaj DbContext i SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=contacts.db"));

// builder.Services.AddControllers().AddJsonOptions(options =>
// {
//     //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
// });



builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IAccountsService, AccountsService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Dodaj globalną konfigurację JSON
// app.Use(async (context, next) =>
// {
//     context.Response.GetTypedHeaders().ContentType = new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/json");
//     await next();
// });


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated(); // Tworzy bazę, jeśli nie istnieje
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapAccountEndpoints();
app.MapSlaContractEndpoints();
app.MapCaseEndpoints();
app.MapContactEndpoints();
app.MapEmailEndpoints();
app.MapLicenseEndpoints();
app.MapNoteEndpoints();
app.MapProductEndpoints();
app.MapReportEndpoints();
app.MapUserEndpoints();



app.Run();
