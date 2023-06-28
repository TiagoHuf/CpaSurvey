using Biopark.CpaSurvey.Domain.Interfaces.Infrastructure;
using Biopark.CpaSurvey.Infra.Data.Context;
using Biopark.CpaSurvey.Infra.Data.Management;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Biopark.CpaSurvey.Infra.CrossCutting.IoC;
using System.Text.Json.Serialization;
using Biopark.CpaSurvey.Application.Perguntas.Queries.GetPergunta;
using Microsoft.OpenApi.Models;
using Biopark.CpaSurvey.Infra.CrossCutting.Filters;
using Biopark.CpaSurvey.Infra.CrossCutting.Behaviours;
using Biopark.CpaSurvey.Infra.Auth.Services;
using System.Text;
using Biopark.CpaSurvey.Infra.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Biopark.CpaSurvey.DomainService.Interfaces;
using Biopark.CpaSurvey.Domain.Interfaces.Services;
using Biopark.CpaSurvey.DomainService.Services.Autenticacao;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "CPA-Survey API",
            Version = "v1",
            Description = "API REST para uso no sistema de perguntas da Comissão Própria de Avaliação do Biopark Educação.",
        }
    );

    c.EnableAnnotations();

    c.DescribeAllParametersInCamelCase();

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Coloque aqui o token obtido através de enpoint de autenticação via Bearer.",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer",
                },
            },
            Array.Empty<string>()
        },
    });


});

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}). AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddScoped<ITokenService, TokenService>();

//Adiciona o contexto para gerar migration
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseMySql(
                    builder.Configuration.GetConnectionString("ApplicationDbContext"), serverVersion,
                    b => b.MigrationsAssembly("Biopark.CpaSurvey.Infra.Data"));
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IAutenticacaoService, AutenticacaoService>();

builder.Services.AddControllersWithViews(
    config =>
    config.Filters.Add(new ApiExceptionFilterAttribute())
    )
    .AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles
);

var appAssemblie = typeof(GetPerguntaQuery).Assembly;
builder.Services.AddMediatR(appAssemblie);
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddFluentValidationDependency(appAssemblie);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ApplicationDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();