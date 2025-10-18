namespace KPO.Example.Models.States;

public class ArchivedProjectState : IProjectState
{
    public IProjectState SendToVerification()
    {
        return this;
    }

    public IProjectState SetOnWork()
    {
        return this;
    }

    public IProjectState Archive()
    {
        return this;
    }

    public IProjectState Pause()
    {
        return this;
    }
}