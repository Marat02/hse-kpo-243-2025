using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Visitors;

public interface ICheckVisitor
{
    public void ForPartCheck(PartCheck check);
    
    public void ForCommonCheck(CommonCheck check);
}