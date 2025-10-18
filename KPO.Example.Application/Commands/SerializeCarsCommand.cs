using KPO.Example.Models.Strategies;

namespace KPO.Example.Application.Commands;

public class SerializeCarsCommand : ICommand<string>
{
    private readonly ICarStrategy _carStrategy;

    public SerializeCarsCommand(ICarStrategy carStrategy)
    {
        _carStrategy = carStrategy;
    }

    public string Execute()
    {
        return _carStrategy.Serialize();
    }

    public void Undo()
    {
    }
}