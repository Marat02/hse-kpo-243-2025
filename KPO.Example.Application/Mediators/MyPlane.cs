namespace KPO.Example.Application.Mediators;

public class MyPlane : ISender
{
    private IMediator _mediator;

    public MyPlane(IMediator mediator)
    {
        _mediator = mediator;
    }

    public void Send()
    {
        _mediator.Send("Hello from MyPlane", this);
    }
    
    public void GetMessage(string message)
    {
        Console.WriteLine($"MyPlane: {message}");
    }
}