namespace KPO.Example.Models.States;

public class DraftProjectState : IProjectState
{
    public IProjectState SendToVerification()
    {
        return new VerificationProjectState();
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