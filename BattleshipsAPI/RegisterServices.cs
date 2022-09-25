using BattleshipsCore.Entities;
using BattleshipsCore.Game.Commands;
using BattleshipsCore.Game.Handlers;
using BattleshipsCore.Game.Queries;
using BattleshipsCore.Game.Services;
using BattleshipsCore.Game.Services.Interfaces;
using MediatR;

namespace BattleshipsAPI;

public static class RegisterServices
{
    public static void RegisterBattleships(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IGameManager, GameManager>()
            .AddScoped<IRequestHandler<CreateShipCommand, bool>, CreateShipCommandHandler>()
            .AddScoped<IRequestHandler<GetPossibleShipsQuery, Dictionary<int, int>>, GetPossibleShipsQueryHandler>()
            .AddScoped<IRequestHandler<GetGameStatusQuery, GameStatus>, GetGameStatusQueryHandler>()
            .AddScoped<IRequestHandler<TakeShotCommand, bool>, TakeShotCommandHandler>();
    }
}