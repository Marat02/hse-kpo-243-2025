namespace KPO.Example.Application.Mediators;

public class MyCar : ISender
{
    private IMediator _mediator;

    public MyCar(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send()
    {
        _mediator.Send("Hello from MyCar", this);
    }

    public void GetMessage(string message)
    {
        Console.WriteLine($"MyCar: {message}");
    }
}