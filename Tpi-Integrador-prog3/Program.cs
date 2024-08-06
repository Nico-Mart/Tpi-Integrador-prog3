using Microsoft.EntityFrameworkCore;
using Infrastructure.Data;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.OpenApi.Models;
using Infrastructure.Data.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication;
using System.Reflection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ApiBearerAuth", new OpenApiSecurityScheme()
    {
        Type= SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "TokenLog"
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "ApiBearerAuth" } }, new List<string>() }

    });
});

// Configuración de la base de datos
builder.Services.AddDbContext<AlbunsContext>(dbContextOptions => dbContextOptions.UseSqlite(
    builder.Configuration["DB:ConnectionStrings"]));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configuración de autenticación JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        var issuer = builder.Configuration["AutenticacionService:Issuer"];
        var audience = builder.Configuration["AutenticacionService:Audience"];
        var secretForKey = builder.Configuration["AutenticacionService:SecretForKey"];

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = issuer,
            ValidAudience = audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretForKey))
        };
    });


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("Musician", policy => policy.RequireClaim(ClaimTypes.Role, "Musician", "Admin"));
    options.AddPolicy("Subscriber", policy => policy.RequireClaim(ClaimTypes.Role, "Subscriber", "Admin"));
    options.AddPolicy("All", policy => policy.RequireClaim(ClaimTypes.Role, "Admin", "Musician", "Subscriber"));
});
// Configuración de dependencias
#region Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IAlbunRepository, AlbunRepository>();
#endregion

#region Services
builder.Services.Configure<AutenticacionServiceOptions>(
    builder.Configuration.GetSection(AutenticacionServiceOptions.AutenticacionService));
builder.Services.AddScoped<ICustomAuthenticacionService, AuthenticacionService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IAlbunService, AlbunService>();
builder.Services.AddScoped<IOperationResultService , OperationResultService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
