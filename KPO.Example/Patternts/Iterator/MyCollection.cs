using System.Collections;

namespace KPO.Example.Patternts.Iterator;

public class MyCollection : IEnumerable<int>
{
    private MyItem _firstItem;

    public MyCollection(MyItem firstItem)
    {
        _firstItem = firstItem;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return new MyEnumerator(_firstItem);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}