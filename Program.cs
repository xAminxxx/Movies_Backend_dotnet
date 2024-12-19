using Backend.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Register the DbContext with MySQL
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Dbcon"),
        MySqlServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Dbcon"))
    ));

// Add Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Register repositories for DI (Dependency Injection)
builder.Services.AddScoped<IActeurRepository, ActeurRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IEditeurRepository, EditeurRepository>();
builder.Services.AddScoped<ILangueRepository, LangueRepository>();
builder.Services.AddScoped<IRealisateurRepository, RealisateurRepository>();

// If you're using a generic IRepository<T>, register it for each entity type.
builder.Services.AddScoped<IRepository<Acteur>, Repository<Acteur>>();
builder.Services.AddScoped<IRepository<Film>, Repository<Film>>();
builder.Services.AddScoped<IRepository<Category>, Repository<Category>>();
builder.Services.AddScoped<IRepository<Editeur>, Repository<Editeur>>();
builder.Services.AddScoped<IRepository<Langue>, Repository<Langue>>();
builder.Services.AddScoped<IRepository<Realisateurs>, Repository<Realisateurs>>();

// Add CORS services to allow requests from the front-end (React)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        builder.WithOrigins("http://localhost:5173")  // Allow the front-end React app's URL
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials();
    });
});

// Add controllers
builder.Services.AddControllers();

// Add JWT Bearer Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
        };
    });

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Configure Swagger to use Bearer Authentication
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Description = "Enter your Bearer token like this: **Bearer YOUR_TOKEN**",
        Type = SecuritySchemeType.ApiKey,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

// Enable Swagger in development and set up Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        options.RoutePrefix = "docs";  // Swagger UI route
    });
}

app.UseStaticFiles();  // Enable static file serving for wwwroot (uploads, etc.)
// Enable HTTPS redirection
app.UseHttpsRedirection();

// Enable Authentication and Authorization (JWT authentication)
app.UseAuthentication();
app.UseAuthorization();

// Enable CORS policy globally
app.UseCors("AllowReactApp");  // Apply the CORS policy

// Map controllers (API endpoints)
app.MapControllers();

// Run the application
app.Run();
