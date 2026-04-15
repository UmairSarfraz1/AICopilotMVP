using AICopilot.Application.Interfaces;
using AICopilot.Application.Tools;
using AICopilot.Application.UseCases;
using AICopilot.Infrastructure;
using AICopilot.Infrastructure.OpenAI;
using AICopilot.Infrastructure.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonSetting>(
    builder.Configuration.GetSection("JsonSetting"));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IChatHandler, ChatHandler>();
builder.Services.AddScoped<IToolExecuter, ToolExecutor>();
builder.Services.AddScoped<IOpenAiService, OpenAIService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();  
app.UseAuthorization();
app.MapControllers();

app.Run();

