using System.Collections;

namespace KPO.Example.Patternts.Enumerator;

public class MyEnumerator : IEnumerator<int>
{
    private readonly MyItem _first;
    private MyItem _current;

    public MyEnumerator(MyItem first)
    {
        _first = first;
        _current = first;
    }

    public bool MoveNext()
    {
        if (_current.Next == null)
            return false;
        _current = _current.Next;
        return true;
    }

    public void Reset()
    {
        _current = _first;
    }

    int IEnumerator<int>.Current => _current.Id;

    public object? Current => _current;


    public void Dispose()
    {
    }
}