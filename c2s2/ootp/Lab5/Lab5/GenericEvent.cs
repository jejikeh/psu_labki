using System.Collections;

namespace Lab5;

public class GenericEventManager<T, T1> : ICollection<T> where T : SomeEvent<T1>, IEvent, new()
{
    private List<T> _someEvents = new List<T>();
    
    public IEnumerator<T> GetEnumerator()
    {
        return _someEvents.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T item)
    {
        _someEvents.Add(item);
    }

    public void AddRange(T node, int count)
    {
        foreach (var _ in Enumerable.Range(0,count))
            _someEvents.Add(node);
    }
    
    public void Clear()
    {
        _someEvents.Clear();
    }

    public bool Contains(T item)
    {
        return _someEvents.Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        _someEvents.CopyTo(array, arrayIndex);
    }

    public bool Remove(T item)
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
    
    public IEnumerable<T> Find(DateTime date)
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
    
    public static GenericEventManager<T, T1> operator +(GenericEventManager<T, T1> e, T item)
    {
        e.Add(item);
        return e;
    }
    
    public static GenericEventManager<T, T1> operator ++(GenericEventManager<T, T1> e)
    {
        var d = new T();
        e.Add(d);
        return e;
    }
    
    public static GenericEventManager<T, T1> operator <<(GenericEventManager<T, T1> e, int index)
    {
        Console.WriteLine(e[index].Print());
        return e;
    }

    public int Find(T obj)
    {
        return _someEvents.FindIndex(x => x == obj);
    }

    public T Min()
    {
         return _someEvents.MinBy(x => x.MaxTickets);
    }
    
    public T Max()
    {
        return _someEvents.MaxBy(x => x.MaxTickets);
    }
    
    public IEnumerable<T> Sort()
    {
        return _someEvents.ToList().OrderBy(x => x.MaxTickets);
    }

    public int Count => _someEvents.Count;
    public bool IsReadOnly => false;
}