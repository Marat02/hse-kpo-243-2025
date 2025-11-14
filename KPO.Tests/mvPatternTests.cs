using FluentAssertions;
using KPO.Example.Models.Projects;
using KPO.Example.Patternts.MV;
using KPO.Example.Views;

namespace KPO.Tests;

public class mvPatternTests
{
    [Fact]
    public void ProjectPresenterExist_ChangeName_ValidProjectViewName()
    {
        var project = new Project("Test", "Test");
        var view = new ProjectView(project.Id, "Test", "Test");
        var presenter = new ProjectPresenter(view, project);
        presenter.SetName("Test2");
        presenter.View.Name.Should().Be("Test2");
    }
    
    [Fact]
    public void ProjectModelViewExist_ChangeName_ValidProjectName()
    {
        var project = new Project("Test", "Test");
        var view = new ProjectView(project.Id, "Test", "Test");
        var view2 = new ProjectView(project.Id, "Test", "Test");
        var view3 = new ProjectView(project.Id, "Test", "Test");
        var view4 = new ProjectView(project.Id, "Test", "Test");
        var modelView = new ProjectModelView(project);
        
        modelView.OnChangeName += (name) => view = view with {Name = name};
        modelView.OnChangeName += (name) => view2 = view2 with {Name = name};
        modelView.OnChangeName += (name) => view3 = view3 with {Name = name};
        modelView.OnChangeName += (name) => view4 = view4 with {Name = name};
        modelView.SetName("Test2");
        
        view.Name.Should().Be("Test2");
        view2.Name.Should().Be("Test2");
        view3.Name.Should().Be("Test2");
        view4.Name.Should().Be("Test2");
    }
}