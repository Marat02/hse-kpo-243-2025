using System.Collections;

namespace KPO.Example.Patternts.Enumerator;

public class MyCollection : IEnumerable<int>
{
    private readonly MyEnumerator _myEnumerator;

    public MyCollection(MyEnumerator myEnumerator)
    {
        _myEnumerator = myEnumerator;
    }

    public IEnumerator<int> GetEnumerator()
    {
        return _myEnumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}