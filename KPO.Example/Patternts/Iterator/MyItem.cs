namespace KPO.Example.Patternts.Iterator;

public class MyItem
{
    public MyItem(int value, MyItem? next)
    {
        Value = value;
        Next = next;
    }

    public int Value { get; }
    
    public MyItem? Next { get; }
}