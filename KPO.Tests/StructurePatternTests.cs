using FluentAssertions;
using KPO.Example.Composite;
using KPO.Example.Infrastructure.Repositories;
using KPO.Example.Models.Blueprints;
using KPO.Example.Models.Bridge;
using KPO.Example.Models.Cars;
using KPO.Example.Models.Checks;
using KPO.Example.Models.Flyweigth;
using KPO.Example.Models.Projects;

namespace KPO.Tests;

public class StructurePatternTests
{
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