using Blog.Infrastructure.Extensions.ServiceCollections;
using Blog.Infrastructure.Extensions.ApplicationBuilder;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

CtrlCfg.AddControllersExtend(builder.Services);

CtrlCfg.AddCORS(builder.Services);
// HttpsCfg.AddHttps(builder.Services);

Auth.AddAuth(builder.Services, builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DbCtx.AddDbContexts(builder.Services, builder.Configuration);

IoC.AddDependency(builder.Services);

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
DefaultCfg.InitConfigurationAPI(app, app.Environment);

app.Run();