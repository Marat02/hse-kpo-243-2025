using KPO.DDD.Basic;

namespace KPO.CarPreOrder.Domain.Models;

public record Place : IValueObject
{
    public string Address { get; init; }
    
    public DateTime Date { get; init; }
}