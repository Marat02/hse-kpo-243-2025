namespace KPO.Example.Composite;

public class Folder : IComposite
{
    private Folder? _parent;
    
    public string Name { get; private set; }

    public Folder(string name, Folder parent)
    {
        _parent = parent;
        Name = name;
    }

    public Folder(string name)
    {
        Name = name;
    }

    public IComposite? GetParent()
    {
        return _parent;
    }

    public void Move(Folder parent)
    {
        _parent = parent;
    }
    
    public void Rename(string name)
    {
        Name = name;
    }
}