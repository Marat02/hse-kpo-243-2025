using KPO.Example.Contracts.Events;

namespace KPO.Example.Application.Models;

public class CarEventModel
{
    public int Id { get; init; }
    
    public string Name { get; init; }
    
    public CarBuildType Type { get; init; }
    
    public bool IsSuccess { get; set; }
}