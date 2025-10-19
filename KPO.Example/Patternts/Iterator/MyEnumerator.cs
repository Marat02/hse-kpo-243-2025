using System.Collections;

namespace KPO.Example.Patternts.Iterator;

public class MyEnumerator : IEnumerator<int>
{
    private MyItem _currentItem;
    private MyItem _firstItem;

    public MyEnumerator(MyItem firstItem)
    {
        _firstItem = firstItem;
        _currentItem = firstItem;
    }

    public void Dispose()
    {
        
    }

    public bool MoveNext()
    {
        if (_currentItem.Next == null)
            return false;
        
        _currentItem = _currentItem.Next;
        return true;
    }

    public void Reset()
    {
        _currentItem = _firstItem;
    }

    int IEnumerator<int>.Current => _currentItem.Value;

    object? IEnumerator.Current => _currentItem.Value;
}