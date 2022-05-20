using Blog.Infrastructure.Extensions.ServiceCollections;
using Blog.Infrastructure.Extensions.ApplicationBuilder;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

CtrlCfg.AddControllersExtend(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DbCtx.AddDbContexts(builder.Services, builder.Configuration);

IoC.AddDependency(builder.Services);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
DefaultCfg.InitConfigurationAPI(app, app.Environment);

app.Run();