using FluentAssertions;
using KPO.Example.Application.Commands;
using KPO.Example.Application.Mediators;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;
using KPO.Example.Models.Projects;
using Microsoft.Extensions.DependencyInjection;
using IMediator = MediatR.IMediator;

namespace KPO.Tests;

public class BehevioralPatternTests
{
    [Fact]
    public void CommandExist_CreatePRoject_ValidCreation()
    {
        // Arrange
        var collection = new ServiceCollection();
        collection.AddTransient<IInvoker, Invoker>();
        var invoker = collection.BuildServiceProvider().GetRequiredService<IInvoker>();

        var command = new CreateProjectCommand("Project 1", "Target 1");

        // Act
        var project = invoker.Execute(command);

        // Assert
        project.Should().NotBeNull();
        project.Name.Should().Be("Project 1");
        project.Target.Should().Be("Target 1");
    }

    [Fact]
    public void MediatorExist_SendMessage_MessageRecieved()
    {
        // Arrange
        var mediator = new Mediator();
        var plane = new MyPlane(mediator);
        var car = new MyCar(mediator);
        mediator.Register(plane, car);

        // Act
        plane.Send();

        // Assert
        // Проверка, что сообщение было получено
    }
    
    [Fact]
    public void MediatorExist_CreateCar_ValidCreation()
    {
        //Arrange
        var collection = new ServiceCollection();
        collection.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(CreateCarHandler).Assembly));
        var mediator = collection.BuildServiceProvider().GetRequiredService<IMediator>();
        var command = new CreateCarCommand(1, 1);

        //Act
        var car = mediator.Send(command).GetAwaiter().GetResult();

        //Assert
        car.Should().NotBeNull();
        car.Id.Should().Be(1);
        car.BlueprintId.Should().Be(1);
    }

    [Fact]
    public void CommandExist_SerializeCar_ValidSerialization()
    {
        var command = new SerializeCarsCommand(new BigCar(1, 1, 1, 1, 1));
        var result = command.Execute();

        result.Should().Be("BigCar: 1, 1, 1, 1, 1");
    }

    [Fact]
    public void ProjectExist_ProjectCheck_ValidLog()
    {
        var project = new Project("Project 1", "Target 1");
        var check = new PartCheck("Check 1", "Part 1");
        var check2 = new CommonCheck("Check 1");
        project.AddCheck(check);
        project.AddCheck(check2);
        project.ExecuteChecks();
    }
}