using KPO.Example.Models.Visitors;

namespace KPO.Example.Models.Checks;

public class CommonCheck : ICheck
{
    public CommonCheck(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public bool Execute()
    {
        return false;
    }

    public void Accept(ICheckVisitor visitor)
    {
        visitor.ForCommonCheck(this);
    }
}