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
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer(
                    builder.Configuration.GetConnectionString("ApplicationDbContext"),
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