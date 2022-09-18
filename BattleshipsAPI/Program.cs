using BattleshipsCore.Game.Services;
using BattleshipsCore.Game.Services.Interfaces;
using BattleshipsCore.Ships.Commands;
using BattleshipsCore.Ships.Handlers;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped<IRequestHandler<CreateShipCommand, bool>, CreateShipCommandHandler>();
builder.Services.AddSingleton<IGameManager, GameManagerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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