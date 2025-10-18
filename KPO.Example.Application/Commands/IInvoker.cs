namespace KPO.Example.Application.Commands;

public interface IInvoker
{
    T Execute<T>(ICommand<T> command);
}