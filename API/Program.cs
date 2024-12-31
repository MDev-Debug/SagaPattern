using Application;
using CrossCutting;
using Domain.Interface;
using Infra.Data.Data;
using Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .CreateLogger();

builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILogService, LogService>();
builder.Services.AddDbContext<PedidoContext>(options => options.UseInMemoryDatabase("PedidoDb"));
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IPedidoEfetuadoStrategy, PedidoEfetuadoStrategy>();
builder.Services.AddScoped<IAguardandoPagamentoStrategy, AguardandoPagamentoStrategy>();
builder.Services.AddScoped<PedidoSaga>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.MapControllers();

app.Run();
 