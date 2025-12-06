using KPO.CarPreOrder.Application.Repositories;
using KPO.CarPreOrder.Domain.Models;
using KPO.Example.Contracts.Events;
using MassTransit;
using MediatR;

namespace KPO.CarPreOrder.Application.Handlers;

public class CarBuildEventHandler : IConsumer<CarBuildEvent>
{
    private readonly ICarModelRepository _carModelRepository;

    public CarBuildEventHandler(ICarModelRepository carModelRepository)
    {
        _carModelRepository = carModelRepository;
    }

    public async Task Consume(ConsumeContext<CarBuildEvent> context)
    {
        var type = context.Message.Type switch
        {
            CarBuildType.Car => CarType.Car,
            CarBuildType.BigCar => CarType.BigCar,
            _ => throw new ArgumentOutOfRangeException()
        };

        var car = new CarModel(Guid.NewGuid(), context.Message.Id, context.Message.Name, type);
        await _carModelRepository.AddAsync(car, context.CancellationToken);
    }
}