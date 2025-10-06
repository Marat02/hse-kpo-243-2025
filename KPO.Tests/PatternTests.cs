using FluentAssertions;
using KPO.Example.Models;
using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Cars;
using KPO.Example.Patternts.Builder;
using KPO.Example.Patternts.Factories;

namespace KPO.Tests;

public class PatternTests
{
    private readonly string _name = "Test Project";
    private readonly string _target = "Test Target";
    
    [Fact]
    public void CarAbstractFactoryBuild_ValidCreation()
    {
        // Arrange
        var carId = 1;
        var blueprintId = 2;
        var carAbstractFactory = new CarAbstractFactory(carId, blueprintId);

        // Act
        var car = carAbstractFactory.BuildCar();
        var blueprint = carAbstractFactory.BuildBlueprint();

        // Assert
        Assert.NotNull(car);
        Assert.NotNull(blueprint);
        Assert.Equal(carId, car.Id);
        Assert.Equal(blueprintId, blueprint.Id);
        car.Should().BeOfType<Car>();
        blueprint.Should().BeOfType<Blueprint>();
    }

    [Fact]
    public void BigCarAbstractFactoryBuild_ValidCreation()
    {
        // Arrange
        var carId = 1;
        var blueprintId = 2;
        var carWeigth = 100;
        var carLength = 100;
        var carHeight = 100;
        var carAbstractFactory = new BigCarAbstractFactory(carId, blueprintId, carWeigth, carHeight, carLength);

        // Act
        var car = carAbstractFactory.BuildCar();
        var blueprint = carAbstractFactory.BuildBlueprint();

        // Assert
        Assert.NotNull(car);
        Assert.NotNull(blueprint);
        Assert.Equal(carId, car.Id);
        Assert.Equal(blueprintId, blueprint.Id);
        car.Should().BeOfType<BigCar>();
        blueprint.Should().BeOfType<BigBlueprint>();
    }

    [Fact]
    public void BigCarDirectorBuild_ValidCreation()
    {
        // Arrange
        var builder = new BigCarBuilder();
        var director = new BigCarDirector(builder);

        // Act
        var car = director.BuildCar();

        // Assert
        Assert.NotNull(car);
        car.Should().BeOfType<BigCar>();
    }

    [Fact]
    public void SimpleBigCarBuilderBuild_ValidCreation()
    {
        // Arrange
        var carWeigth = 100;
        var carLength = 100;
        var carHeight = 100;
        var blueprintId = 123;
        var carId = 321;
        var builder = new SimpleBigCarBuilder();

        // Act
        var car = builder.SetBlueprintId(blueprintId).SetCarWeigth(carWeigth).SetCarHeight(carHeight)
            .SetCarLength(carLength).SetId(carId).Build();

        // Assert
        Assert.NotNull(car);
        Assert.Equal(carId, car.Id);
        Assert.Equal(blueprintId, car.BlueprintId);
        Assert.Equal(carWeigth, car.Weigth);
        Assert.Equal(carLength, car.Length);
        Assert.Equal(carHeight, car.Height);
    }

    [Fact]
    public void BluePrintPrototypeClone_ValidClone()
    {
        // Arrange
        var blueprintId = 123;
        var blueprint = new Blueprint(blueprintId);

        // Act
        var clone = blueprint.Clone();

        // Assert
        Assert.NotNull(clone);
        Assert.Equal(blueprintId, clone.Id);
        clone.Should().NotBe(blueprint);
    }

    [Fact]
    public void Singletone()
    {
        // Arrange
        var project = new Project(_name, _target);
        var project2 = new Project("321", "123");

        // Act
        var refCar1 = project.GetReferenceCar();
        var refCar2 = project2.GetReferenceCar();

        // Assert
        refCar1.Should().Be(refCar2);
    }
}