using System.Collections;
using System.Runtime.InteropServices.JavaScript;

namespace Lab1;

public class EventManager : ICollection<SomeEvent>
{
    private List<SomeEvent> _someEvents = new List<SomeEvent>();
    
    public IEnumerator<SomeEvent> GetEnumerator()
    {
        return _someEvents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(SomeEvent item)
    {
        _someEvents.Add(item);
    }
    
    public void Clear()
    {
        _someEvents.Clear();
    }

    public bool Contains(SomeEvent item)
    {
        return _someEvents.Contains(item);
    }

    public void CopyTo(SomeEvent[] array, int arrayIndex)
    {
        _someEvents.CopyTo(array, arrayIndex);
    }

    public bool Remove(SomeEvent item)
    {
        return _someEvents.Remove(item);
    }
    
    public void Remove(int index)
    {
        _someEvents.RemoveAt(index);
    }

    public SomeEvent? Find(string title)
    {
        return _someEvents.FirstOrDefault(x => x.Title == title);
    }
    
    public IEnumerable<SomeEvent> Find(DateTime date)
    {
        return _someEvents.Where(x => x.Date == date);
    }
    
    public SomeEvent this[int index] => _someEvents[index];

    public int Count => _someEvents.Count;
    public bool IsReadOnly => false;
}