namespace KPO.Example.Models.States;

public class OnWorkProjectState : IProjectState
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
        return new ArchivedProjectState();
    }

    public IProjectState Pause()
    {
        return new PausedProjectState();
    }
}