namespace KPO.Example.Models.Checks;

public class CommonCheck : ICheck
{
    public string Name { get; }

    public bool Execute()
    {
        return false;
    }
}