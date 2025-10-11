namespace KPO.Example.Patternts.Commands;

public class CreateProjectCommand : BaseCommand
{
    private readonly string _projectName;

    public CreateProjectCommand(string projectName)
    {
        _projectName = projectName;
    }

    internal override void Do()
    {
    }

    internal override void Undo()
    {
    }
}