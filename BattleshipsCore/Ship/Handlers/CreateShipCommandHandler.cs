using BattleshipsCore.Ship.Commands;
using MediatR;

namespace BattleshipsCore.Ship.Handlers;

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, bool>
{
    public Task<bool> Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}