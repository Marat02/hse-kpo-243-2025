using KPO.Example.Contracts.Events;
using KPO.Example.Models.Entities;
using KPO.Example.Utils;
using MassTransit;

namespace KPO.Example.Application.Consumers;

public class ProjectCreatedConsumer : IConsumer<ProjectCreatedEvent>
{
    private readonly IUnitOfWork _unitOfWork;

    public ProjectCreatedConsumer(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Consume(ConsumeContext<ProjectCreatedEvent> context)
    {
        var processedEvent = await _unitOfWork.ProcessedEventRepository.Get(context.Message.EventId, context.CancellationToken);
        if (processedEvent is not null)
            return;

        await _unitOfWork.ProcessedEventRepository.AddAsync(new ProcessedEvent
        {
            Id = context.Message.EventId,
            Type = nameof(ProjectCreatedEvent)
        }, context.CancellationToken);
        
        var entity = await _unitOfWork.EntityCountRepository.Get("project", context.CancellationToken);
        if (entity is null)
        {
            entity = new EntityCount
            {
                Name = "project",
                Count = 1
            };
            await _unitOfWork.EntityCountRepository.Add(entity, context.CancellationToken);
        }
        else
        {
            entity.Count++;
            await _unitOfWork.EntityCountRepository.Update(entity, context.CancellationToken);
        }
        
        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
        await _unitOfWork.SaveChangesAsync(context.CancellationToken);
    }
}