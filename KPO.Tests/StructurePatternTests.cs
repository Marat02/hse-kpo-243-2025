using FluentAssertions;
using KPO.Example.Application.Mediators;
using KPO.Example.Application.Services;
using KPO.Example.Composite;
using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Bridge;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;
using KPO.Example.Models.Flyweigth;
using KPO.Example.Models.Projects;
using Microsoft.Extensions.DependencyInjection;
using IMediator = MediatR.IMediator;

namespace KPO.Tests;

public class StructurePatternTests
{
    [Fact]
    public void AdapterExist_Adapter_ValidAdapter()
    {
        // Arrange
        var id = Guid.NewGuid();
        var projectDao = new ProjectDao(id, "Project 1", "Target 1", new List<ICar>(), new List<IBlueprint>(), new List<ICheck>());
        var adapter = new ProjectRepository([projectDao]);
        var project = new Project(adapter);
        
        // Act
        project.Load(id);

        // Assert
        project.Id.Should().NotBe(Guid.Empty);
        project.Name.Should().Be("Project 1");
        project.Target.Should().Be("Target 1");
    }

    [Fact]
    public void FacadeExist_CreateProject_ValidProject()
    {
        // Arrange
        var collection = new ServiceCollection();
        collection.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateCarHandler).Assembly));
        
        var facade = new ProjectService(collection.BuildServiceProvider().GetRequiredService<IMediator>(), new ProjectRepository());

        // Act
        var project = facade.CreateProject("Project 1", "Target 1");

        // Assert
        project.Name.Should().Be("Project 1");
        project.Target.Should().Be("Target 1");
    }

    [Fact]
    public void ProxyExist_ProjectRepository_ValidProjectRepository()
    {
        var id = Guid.NewGuid();
        var projectDao = new ProjectDao(id, "Project 1", "Target 1", new List<ICar>(), new List<IBlueprint>(), new List<ICheck>());
        var adapter = new ProjectRepositoryProxy([projectDao]);
        var project = new Project(adapter);
        
        // Act
        project.Load(id);

        // Assert
        project.Id.Should().NotBe(Guid.Empty);
        project.Name.Should().Be("Project 1");
        project.Target.Should().Be("Target 1");
    }
    
    [Fact]
    public void CompositeExist_FolderCheck_ValidFolderCheck()
    {
        // Arrange
        var folder = new Folder("Folder 1");
        var folderCheck = new FolderCheck("Folder 1", folder);

        // Act
        var parent = folderCheck.GetParent();
        folderCheck.Rename("Folder 2");

        // Assert
        parent.Should().Be(folder);
        folderCheck.Name.Should().Be("Folder 2");
    }

    [Fact]
    public void BridgeExist_CallClient_ValidCall()
    {
        var client = new Client();
        var broker = new Broker(client);

        var message = broker.Send();
        message.Should().Be("Message");
    }

    [Fact]
    public void FlyweigthExist_GetCheck_ValidCheck()
    {
        var factory = new CheckFactory();
        var check = factory.GetCheck("Common");
        var check2 = factory.GetCheck("Part");
        var check3 = factory.GetCheck("Folder");
        var check4 = factory.GetCheck("Folder");

        check.Name.Should().Be("Common");
        check2.Name.Should().Be("Common");
        check3.Name.Should().Be("Common");

        check.Should().BeOfType<CommonCheck>();
        check2.Should().BeOfType<PartCheck>();
        check3.Should().BeOfType<FolderCheck>();

        check4.Should().Be(check3);
    }
}