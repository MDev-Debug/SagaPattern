using Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin => true) // Permite qualquer origem
            .AllowCredentials();
    });
});

var env_redis = Environment.GetEnvironmentVariable("REDIS_CONNECTION") ?? "localhost:6379";

// Configurar Redis como backplane para SignalR
builder.Services.AddSignalR(opt =>
{
    opt.EnableDetailedErrors = true;
})
    .AddStackExchangeRedis(env_redis, options =>
    {
        options.Configuration.ClientName = Environment.GetEnvironmentVariable("SERVER").ToString();
    });

var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseCors();
app.Use(async (context, next) =>
{
    var origin = context.Request.Headers["Origin"];
    if (!string.IsNullOrEmpty(origin))
    {
        context.Response.Headers.Add("Access-Control-Allow-Origin", origin);
        context.Response.Headers.Add("Vary", "Origin");
    }
    await next();
});

app.MapHub<ChatHub>("/chat");

app.MapControllers();

app.Run();
