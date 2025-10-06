namespace KPO.Example.Models.Checks;

public interface ICheck
{
    public string Name { get; }
    
    bool Execute();
}