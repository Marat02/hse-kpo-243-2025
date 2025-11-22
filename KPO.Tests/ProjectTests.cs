using FluentAssertions;
using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Checks;
using KPO.Example.Models.Projects;
using KPO.Example.Patternts.Factories;
using NSubstitute;
using Xunit.Abstractions;

namespace KPO.Tests;

/// <summary>
/// Unit тесты для класса Project.
/// </summary>
public class ProjectTests : IClassFixture<ProjectTestFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly string _name = "Test Project";
    private readonly string _target = "Test Target";
    
    /// <summary>
    /// Идентификатор для примера работы unit тестов. Данный id для всех тестов будет разный, а тот что в фисктуре будет одинаковый.
    /// </summary>
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
        var test = new PartCheck("Test", "Test");

        // Act
        project.AddCheck(test);

        // Assert
        Assert.Contains(test, project.Checks);
    }

    [Fact]
    public void ProjectWithTestExist_ExecuteTests_Success()
    {
        // Arrange
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var test = Substitute.For<ICheck>();
        test.Execute().Returns(true);
        project.AddCheck(test);

        // Act
        var result = project.ExecuteChecks();

        // Assert
        Assert.True(result);
        test.Received(1).Execute();
    }

    [Fact]
    public void ProjectExist_BuildCar_ValidCarCreated()
    {
        // Arrange
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var blueprint = new Blueprint(1);
        project.AddBlueprint(blueprint);
        var carAbstractMethod = new CarAbstractMethod(2);

        //Act
        var result = project.BuildCar(1, "TestName", carAbstractMethod);

        //Assert
        Assert.True(result);
        project.Cars.Should().Contain(t => t.Id == 2);
    }

    [Fact]
    public void ProjectExist_BuildBigCar_ValidCarCreated()
    {
        // Arrange
        var carWeigth = 100;
        var carLength = 100;
        var carHeight = 100;
        var blueprintId = 123;
        var carId = 321;
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var blueprint = new BigBlueprint(blueprintId, carWeigth, carHeight, carLength);
        project.AddBlueprint(blueprint);
        var carAbstractMethod = new BigCarAbstractMethod(carId);

        //Act
        var result = project.BuildCar(blueprintId, "TestName", carAbstractMethod);

        //Assert
        Assert.True(result);
        project.Cars.Should().Contain(t => t.Id == carId);
    }

    [Fact]
    public void ProjectExist_BuildBigCar_NotValidCarCreated()
    {
        // Arrange
        var carWeigth = 100;
        var carLength = 100;
        var carHeight = 100;
        var blueprintId = 123;
        var carId = 321;
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);
        var blueprint = new BigBlueprint(blueprintId, carWeigth, carHeight, carLength);
        var carAbstractMethod = new BigCarAbstractMethod(carId);

        //Act
        var result = project.BuildCar(blueprintId, "TestName", carAbstractMethod);

        //Assert
        Assert.False(result);
        project.Cars.Should().NotContain(t => t.Id == carId);
    }

    [Fact]
    public void ProjectExist_ProjectDao_ValidProjectDao()
    {
        // Arrange
        const string name = "Test Project";
        const string target = "Test Target";
        var project = new Project(name, target);

        //Act
        project.AddBlueprint(new Blueprint(1));
        var result = project.ToDao();
        project.SetName("new Name");
        project.FromDao(result);
        var project2 = new Project("new Name", "new target");
        project2.FromDao(result);

        //Assert
        Assert.NotNull(result);
        result.Should().NotBeNull();
        result.Name.Should().Be(name);
        result.Target.Should().Be(target);
        project.Name.Should().Be(name);
        project.Target.Should().Be(target);
        project2.Name.Should().Be(name);
        project2.Target.Should().Be(target);
        project2.Blueprints.Count.Should().Be(project.Blueprints.Count);
    }
}