using System.Collections.Concurrent;
using Blog.Infrastructure.Extensions.ServiceCollections;
using Blog.Infrastructure.Extensions.ApplicationBuilder;

var builder = WebApplication.CreateBuilder(args);

CtrlCfg.AddControllersExtend(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DbCtx.AddDbContexts(builder.Services, builder.Configuration);

IoC.AddDependency(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
DefaultCfg.InitConfigurationAPI(app, app.Environment);

app.Run();