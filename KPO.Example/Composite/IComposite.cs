namespace KPO.Example.Composite;

public interface IComposite
{
    IComposite? GetParent();
    
    public string Name { get; }
}