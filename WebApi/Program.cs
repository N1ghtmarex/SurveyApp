using Application;
using Domain;
using Common;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using WebApi.Middleware;
using System.Xml.Linq;
using System.Xml.XPath;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDataAccessService(builder.Configuration);
builder.Services.RegisterUseCasesService();
builder.Services.RegisterCommonServices();
builder.Services.RegisterInfrastructureServices();

builder.Services.AddSwaggerGen(options =>
{
Directory
    .GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly)
    .ToList()
    .ForEach(xmlFile =>
    {
        var doc = XDocument.Load(xmlFile);
        options.IncludeXmlComments(() => new XPathDocument(doc.CreateReader()), includeControllerXmlComments: true);
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddAuthorization();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.WithOrigins("https://localhost:5174");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

builder.Services.AddControllers();

var app = builder.Build();


app.MigrateDb();

app.UseRouting();

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
