using KPO.Example.Models.Projects;
using KPO.Example.Views;

namespace KPO.Example.Patternts.MV;

public class ProjectPresenter
{
    public ProjectView View { get; private set; }
    
    private readonly Project _project;

    public ProjectPresenter(ProjectView view, Project project)
    {
        View = view;
        _project = project;
    }

    public void SetName(string name)
    {
        _project.SetName(name);
        View = View with {Name = _project.Name};
    }
}