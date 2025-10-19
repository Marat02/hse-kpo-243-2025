using KPO.Example.Models.Checks;
using KPO.Example.Models.Visitors;

namespace KPO.Example.Composite;

public class FolderCheck : ICheck, IComposite
{
    private Folder _parent;
    
    public string Name { get; private set; }

    public FolderCheck(string name, Folder parent)
    {
        _parent = parent;
        Name = name;
    }

    public IComposite? GetParent()
    {
        return _parent;
    }

    public bool Execute()
    {
        return true;
    }

    public void Accept(ICheckVisitor visitor)
    {
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