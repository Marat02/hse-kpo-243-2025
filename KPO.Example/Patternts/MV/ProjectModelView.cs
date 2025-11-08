using KPO.Example.Models.Projects;

namespace KPO.Example.Patternts.MV;

public class ProjectModelView
{
    private readonly Project _project;

    public delegate void ChangeName(string name);
    
    public event ChangeName? OnChangeName;

    public ProjectModelView(Project project)
    {
        _project = project;
    }
    
    public void SetName(string name)
    {
        _project.SetName(name);
        OnChangeName?.Invoke(name);
    }
}