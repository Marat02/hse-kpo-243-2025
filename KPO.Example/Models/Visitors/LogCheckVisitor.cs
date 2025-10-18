using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Visitors;

public class LogCheckVisitor : ICheckVisitor
{
    public void ForPartCheck(PartCheck check)
    {
        Console.WriteLine($"Part check: Name {check.PartName}, PartId {check.PartName}");
    }

    public void ForCommonCheck(CommonCheck check)
    {
        Console.WriteLine($"Common check: Name {check.Name}");
    }
}