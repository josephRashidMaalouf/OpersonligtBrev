using JobSeekerAssistant.Api.DependecyInjection;
using JobSeekerAssistant.Application.Interfaces.Repositories;
using JobSeekerAssistant.Application.Interfaces.Services;
using JobSeekerAssistant.Application.Services;
using JobSeekerAssistant.Domain.Entities.Identity;
using JobSeekerAssistant.Infrastructure;
using JobSeekerAssistant.Infrastructure.Repositories.MongoDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionString = builder.Configuration["Database:Local:Sql"];
var mongoConnectionString = builder.Configuration["Database:Cloud:Mongo"];
var gptKey = builder.Configuration["GptKey"];

builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
builder.Services.AddAuthorizationBuilder();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(sqlConnectionString);
});
builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

builder.Services.AddScoped<IResumeRepository<string>, ResumeRepository>(provider =>
    new ResumeRepository("Resumes", mongoConnectionString!));
builder.Services.AddScoped<ILetterRepository<string>, LetterRepository>(provider =>
    new LetterRepository("Letters", mongoConnectionString!));

builder.Services.InjectServices();



builder.Services.AddHttpClient("GptApi", options =>
{
    options.BaseAddress = new Uri("https://api.openai.com");
}).ConfigureHttpClient(client =>
{
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", builder.Configuration["GptKey"]);
});

builder.Services.AddCors(
    options => options.AddPolicy(
        "wasm",
        policy => policy.WithOrigins("https://localhost:7297", "https://localhost:7137")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("wasm");


app.MapIdentityApi<User>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
