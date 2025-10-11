namespace KPO.Example.Patternts.Commands;

public abstract class BaseCommand
{
    internal abstract void Do();
    
    internal abstract void Undo();
}