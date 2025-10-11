namespace KPO.Example.Patternts.Commands;

public class Invoker
{
    private List<BaseCommand> _commands = new List<BaseCommand>();

    public void AddCommand(BaseCommand command)
    {
        _commands.Add(command);
    }
    
    public void ExecuteCommands()
    {
        foreach (var command in _commands)
        {
            command.Do();
        }
    }
}