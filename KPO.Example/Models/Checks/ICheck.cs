using KPO.Example.Models.Visitors;

namespace KPO.Example.Models.Checks;

public interface ICheck
{
    public string Name { get; }
    
    bool Execute();
    
    public void Accept(ICheckVisitor visitor);
}