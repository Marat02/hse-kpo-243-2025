namespace KPO.Example.Application.Mediators;

public class Mediator : IMediator
{
    private ISender? _sender1;
    private ISender? _sender2;

    public void Register(ISender sender1, ISender sender2)
    {
        _sender1 = sender1;
        _sender2 = sender2;
    }

    public void Send(string message, object sender)
    {
        if (_sender1 == sender)
            _sender2?.GetMessage(message);
        else if (_sender2 == sender)
            _sender1?.GetMessage(message);
    }
}