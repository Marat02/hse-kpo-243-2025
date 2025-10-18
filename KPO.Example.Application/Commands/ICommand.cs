namespace KPO.Example.Application.Commands;

public interface ICommand<out T>
{
    T Execute();

    void Undo();
}