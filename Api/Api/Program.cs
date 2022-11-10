using Blog.Domain;
using Blog.Primitives;
using Microsoft.Extensions.Logging;
using Blog.Services;
using Blog.Infrastructures;
using Infrastructures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddLogging();
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
app.UseRouting();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    }
);

app.MapControllers();

app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // must be singleton because we compare the instance references when merging DefinitiveListFile instances.

    services.AddTransient<IBlogService, BlogService>();
    services.AddTransient<IBlogDomain, BlogDomain>();
    services.AddTransient<INotionBlogs, NotionBlogs>();
    services.AddSingleton<ILoggerFactory, LoggerFactory>();
    services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
    services.Configure<NotionSettings>(configuration.GetSection("NotionSettings"));
}

