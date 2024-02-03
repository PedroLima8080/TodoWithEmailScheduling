using RabbitMQ.Client.Events;
using Todo.Application.Context;
using Todo.Application.MIddlewares;
using Todo.Application.Repositories;
using Todo.Application.Services;
using Todo.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<DataContext>();
builder.Services.AddScoped<MessageService>();
builder.Services.AddScoped<StatusRepository>();
builder.Services.AddScoped<StatusService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<TodoRepository>();
builder.Services.AddScoped<TodoService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
