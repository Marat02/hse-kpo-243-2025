namespace KPO.Example.Models.Checks;

public class PartCheck : ICheck
{
    public string Name { get; }

    public bool Execute()
    {
        return false;
    }
}