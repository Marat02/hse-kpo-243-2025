using KPO.Example.Models.Projects;

namespace KPO.Example.Application.Commands;

public class CreateProjectCommand : ICommand<Project>
{
    private Project? _project;
    
    public CreateProjectCommand(string name, string target)
    {
        Name = name;
        Target = target;
    }

    public string Name { get; }
    public string Target { get; }
    
    public Project Execute()
    {
        _project = new Project(Name, Target);
        return _project;
    }

    public void Undo()
    {
        _project = null;
    }
}