using KPO.Example.Models.Visitors;

namespace KPO.Example.Models.Checks;

public class PartCheck : ICheck
{
    public PartCheck(string name, string partName)
    {
        Name = name;
        PartName = partName;
    }

    public string Name { get; }

    public string PartName { get; }

    public bool Execute()
    {
        return false;
    }

    public void Accept(ICheckVisitor visitor)
    {
        visitor.ForPartCheck(this);
    }
}