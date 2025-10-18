namespace KPO.Example.Models.States;

public class PausedProjectState : IProjectState
{
    public IProjectState SendToVerification()
    {
        return this;
    }

    public IProjectState SetOnWork()
    {
        return new OnWorkProjectState();
    }

    public IProjectState Archive()
    {
        return new ArchivedProjectState();
    }

    public IProjectState Pause()
    {
        return this;
    }
}