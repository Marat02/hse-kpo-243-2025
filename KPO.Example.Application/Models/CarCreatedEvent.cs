using KPO.Example.Contracts.Events;

namespace KPO.Example.Application.Models;

public class CarCreatedEvent
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public CarBuildType Type { get; set; }
    
    public bool IsCompleted { get; set; }
}