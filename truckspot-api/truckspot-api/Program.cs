using truckspot_api.Config.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAppServices(builder.Configuration);
builder.Services.AddAppRepositories();
builder.Services.AddAppControllers();

var app = builder.Build();

app.BuildSwagger();
app.MapControllers();
app.Run();