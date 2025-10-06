using KPO.Example.Models.Cars;

namespace KPO.Example.Patternts.Builder;

public interface IBigCarBuilder
{
    public void SetId(int id);
    
    public void SetBlueprintId(int blueprintId);
    
    public void SetCarWeigth(int carWeigth);
    
    public void SetCarHeight(int carHeight);
    
    public void SetCarLength(int carLength);
    
    public ICar Build();
}