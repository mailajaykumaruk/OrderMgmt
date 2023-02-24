using Microsoft.EntityFrameworkCore;
using AcmeCorpTesting.Models;
using AcmeCorpTesting.Processor;
using AcmeCorpTesting.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(x => x.Filters.Add<ApiKeyAuthFilter>());
builder.Services.AddSingleton<CustomerProcessor>();
builder.Services.AddSingleton<CustomerContactInfoProcessor>();
builder.Services.AddSingleton<CustomerOrderProcessor>();

builder.Services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("OrderManagement"));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(f =>
{
    f.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Description = "The API Key to access the API",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Name="x-api-key",
        In= Microsoft.OpenApi.Models.ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });

    var scheme = new OpenApiSecurityScheme
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id="ApiKey"
        },
        In=ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
    {
        { scheme, new List<string>() }
    };

    f.AddSecurityRequirement(requirement);
});

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
