using KPO.CarPreOrder.Domain.Models;
using KPO.Example.Contracts.Events;
using MediatR;

namespace KPO.CarPreOrder.Application.Handlers;

public class CarBuildEventHandler : INotificationHandler<CarBuildEvent>
{
    public Task Handle(CarBuildEvent notification, CancellationToken cancellationToken)
    {
        var type = notification.Type switch
        {
            CarBuildType.Car => CarType.Car,
            CarBuildType.BigCar => CarType.BigCar,
            _ => throw new ArgumentOutOfRangeException()
        };

        var car = new CarModel(Guid.NewGuid(), notification.Id, notification.Name, type);
        return Task.CompletedTask;
    }
}