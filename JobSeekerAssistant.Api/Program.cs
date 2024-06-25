using JobSeekerAssistant.Api.DependecyInjection;
using JobSeekerAssistant.Application.Interfaces.Repositories;
using JobSeekerAssistant.Domain.Entities.Identity;
using JobSeekerAssistant.Infrastructure;
using JobSeekerAssistant.Infrastructure.Repositories.MongoDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlConnectionString = builder.Configuration["Database:Local:Sql"];
var mongoConnectionString = builder.Configuration["Database:Local:Mongo"];
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
