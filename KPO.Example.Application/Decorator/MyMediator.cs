using KPO.Example.Application.Mediators;

namespace KPO.Example.Application.Decorator;

public class MyMediator : IMyMediator
{
    private readonly Mediator _mediator;

    public MyMediator(Mediator mediator)
    {
        _mediator = mediator;
    }

    public void Send(string message)
    {
        Console.WriteLine($"Sending message: {message}");
        _mediator.Send(message, null);
        Console.WriteLine($"Message sent: {message}");
    }
}