using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Infra.Data.Context;
using Biopark.CpaSurvey.Infra.Data.Management;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Text.Json.Serialization;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adiciona o contexto para gerar migration
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseMySql(
                    builder.Configuration.GetConnectionString("ApplicationDbContext"), serverVersion,
                    b => b.MigrationsAssembly("Biopark.CpaSurvey.Infra.Data"));
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var appAssemblie = typeof(GetPerguntaQuery).Assembly;
builder.Services.AddMediatR(appAssemblie);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        //context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpsRedirection();

app.UseCors(
    opt => opt
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

app.MapControllers();

app.Run();