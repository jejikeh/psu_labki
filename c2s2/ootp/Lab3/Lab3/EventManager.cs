using System.Collections;

namespace Lab3;

public class EventManager : ICollection<IEvent>
{
    private List<IEvent> _someEvents = new List<IEvent>();
    
    public IEnumerator<IEvent> GetEnumerator()
    {
        return _someEvents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(IEvent item)
    {
        _someEvents.Add(item);
    }

    public void AddRange<T>(T node, int count) where T : IEvent, new()
    {
        foreach (var _ in Enumerable.Range(0,count))
            _someEvents.Add(new T().Copy(node) ?? throw new InvalidOperationException());
    }
    
    public void Clear()
    {
        _someEvents.Clear();
    }

    public bool Contains(IEvent item)
    {
        return _someEvents.Contains(item);
    }

    public void CopyTo(IEvent[] array, int arrayIndex)
    {
        _someEvents.CopyTo(array, arrayIndex);
    }

    public bool Remove(IEvent item)
    {
        return _someEvents.Remove(item);
    }
    
    public void Remove(int index)
    {
        _someEvents.RemoveAt(index);
    }

    public IEvent? Find(string title)
    {
        return _someEvents.FirstOrDefault(x => x.Title == title);
    }
    
    public IEnumerable<IEvent> Find(DateTime date)
    {
        return _someEvents.Where(x =>
        {
            if (x is SingleEvent someEvent)
                return someEvent.Date == date;
            
            return (x as RepeatedEvent).Date
                    .Any(y => y == date);
        });
    }
    
    public IEvent this[int index] => _someEvents[index];

    public int Count => _someEvents.Count;
    public bool IsReadOnly => false;
}