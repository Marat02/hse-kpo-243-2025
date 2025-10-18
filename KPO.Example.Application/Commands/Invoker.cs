namespace KPO.Example.Application.Commands;

public class Invoker : IInvoker
{
    public T Execute<T>(ICommand<T> command)
    {
        Console.WriteLine($"Invoker: Executing command. {command.GetType().Name}");
        try
        {
            var result = command.Execute();
            Console.WriteLine($"Invoker: Command executed. {command.GetType().Name}");
            return result;
        }
        catch (Exception e)
        {
            command.Undo();
            Console.WriteLine(e);
            throw;
        }
    }
}