namespace KPO.Example.Models.States;

public class VerificationProjectState : IProjectState
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
        return this;
    }

    public IProjectState Pause()
    {
        return this;
    }
}