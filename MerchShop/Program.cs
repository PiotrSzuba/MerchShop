using MerchShop.Api.Controllers;
using MerchShop.Api.Infrastructure.Extensions;
using MerchShop.Service;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Logging.ConfigureLogging();

builder.Services.AddCors();
builder.Services.AddDirectoryBrowser();
builder.Services.AddDatabase(configuration);
builder.Services.AddServicesDependency();
builder.Services.AddSingletonServices(configuration, builder.Environment.ContentRootPath);

var app = builder.Build();

app.ConfigureStaticFiles(builder);
app.ConfigureExceptionHandler();
app.AddCorsPolicy(configuration);
app.AddControllers();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello world !");

app.Run();
