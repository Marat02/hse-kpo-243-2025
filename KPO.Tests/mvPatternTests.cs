using FluentAssertions;
using KPO.Example.Models.Projects;
using KPO.Example.Patternts.MV;
using KPO.Example.Views;

namespace KPO.Tests;

public class mvPatternTests
{
    [Fact]
    public void ProjectPresenterExist_SetName_ValidProjectView()
    {
        var project = new Project("Project 1", "Target 1");
        var view = new ProjectView(Guid.NewGuid(), "Project 1", "Target 1");
        var presenter = new ProjectPresenter(view, project);

        presenter.SetName("Project 2");

        presenter.View.Name.Should().Be("Project 2");
    }

    [Fact]
    public void ProjectModelViewExist_SetName_ValidProjectView()
    {
        var project = new Project("Project 1", "Target 1");
        var projectViewModel = new ProjectModelView(project);
        var view = new ProjectView(Guid.NewGuid(), "Project 1", "Target 1");
        var view2 = new ProjectView(Guid.NewGuid(), "Project 1", "Target 1");
        var view3 = new ProjectView(Guid.NewGuid(), "Project 1", "Target 1");
        var view4 = new ProjectView(Guid.NewGuid(), "Project 1", "Target 1");

        projectViewModel.OnChangeName += (name) =>
        {
            view = view with {Name = name};
            view2 = view2 with {Name = name};
            view3 = view3 with {Name = name};
            view4 = view4 with {Name = name};
        };
        
        projectViewModel.SetName("Project 2");
        view.Name.Should().Be("Project 2");
        view2.Name.Should().Be("Project 2");
        view3.Name.Should().Be("Project 2");
        view4.Name.Should().Be("Project 2");
    }
}