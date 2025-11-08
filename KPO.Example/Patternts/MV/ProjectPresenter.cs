using KPO.Example.Models.Projects;
using KPO.Example.Views;

namespace KPO.Example.Patternts.MV;

public class ProjectPresenter
{
    public ProjectView View { get; private set; }
    private readonly Project _model;

    public ProjectPresenter(ProjectView view, Project model)
    {
        View = view;
        _model = model;
    }

    public void SetName(string name)
    {
        _model.SetName(name);
        View = View with {Name = _model.Name};
    }
}