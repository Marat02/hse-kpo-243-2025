using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Visitors;

public class PoolCheckVisitor : ICheckVisitor
{
    public List<PartCheck> PartChecks = [];

    public List<CommonCheck> Checks = [];
    
    public void ForPartCheck(PartCheck check)
    {
        PartChecks.Add(check);
    }

    public void ForCommonCheck(CommonCheck check)
    {
        Checks.Add(check);
    }
}