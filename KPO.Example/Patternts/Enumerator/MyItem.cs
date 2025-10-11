namespace KPO.Example.Patternts.Enumerator;

public class MyItem
{
    public MyItem(int id, MyItem? next)
    {
        Id = id;
        Next = next;
    }

    public int Id { get; init; }
    public MyItem? Next { get; init; }
}