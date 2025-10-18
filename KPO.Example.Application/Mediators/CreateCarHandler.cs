using KPO.Example.Models.Cars;
using MediatR;

namespace KPO.Example.Application.Mediators;

public class CreateCarHandler : IRequestHandler<CreateCarCommand, Car>
{
    public Task<Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        var result = new Car(request.Id, request.BlueprintId);
        return Task.FromResult(result);
    }
}