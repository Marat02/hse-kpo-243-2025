using KPO.Example.Models.Cars;
using MediatR;

namespace KPO.Example.Application.Mediators;

public class CreateCarCommand : IRequest<Car>
{
    public int Id { get; }
    public int BlueprintId { get; }

    public CreateCarCommand(int id, int blueprintId)
    {
        Id = id;
        BlueprintId = blueprintId;
    }
}