namespace KPO.Example.Models.States;

public interface IProjectState
{
    public IProjectState SendToVerification();
    public IProjectState SetOnWork();
    public IProjectState Archive();
    
    public IProjectState Pause();
}