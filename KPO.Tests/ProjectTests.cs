using FluentAssertions;
using KPO.Example.Models;
using NSubstitute;
using Xunit.Abstractions;
using ITest = KPO.Example.Models.ITest;

namespace KPO.Tests;

public class ProjectTests : IClassFixture<ProjectTestFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _name = "Test Project";
    private readonly string _target = "Test Target";
    private readonly Guid _id = Guid.NewGuid();
    private readonly ProjectTestFixture _fixture;

    public ProjectTests(ITestOutputHelper testOutputHelper, ProjectTestFixture fixture)
    {
        _testOutputHelper = testOutputHelper;
        _fixture = fixture;
    }

    [Fact]
    public void CreateProject_ValidCreation()
    {
        // Arrange
        _testOutputHelper.WriteLine(_fixture.Id.ToString());
        
        // Act
        var project = new Project(_fixture.Name, _fixture.Target);
        
        // Assert
        Assert.NotNull(project);
        project.Should().NotBeNull();
        
        Assert.Equal(_fixture.Name, project.Name);
        project.Name.Should().Be(_fixture.Name);
        
        Assert.Equal(_fixture.Target, project.Target);
    }
    
    [Fact]
    public void EmptyProjectExist_AddTest_TestExist()
    {
        // Arrange
        _testOutputHelper.WriteLine(_fixture.Id.ToString());
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var test = new PartTest();
        
        // Act
        project.AddTest(test);
        
        // Assert
        Assert.Contains(test, project.Tests);
    }
    
    [Fact]
    public void ProjectWithTestExist_ExecuteTests_Success()
    {
        // Arrange
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var test = Substitute.For<ITest>();
        test.Execute().Returns(true);
        project.AddTest(test);
        
        // Act
        var result = project.ExecuteTests();
        
        // Assert
        Assert.True(result);
        test.Received(1).Execute();
    }
}