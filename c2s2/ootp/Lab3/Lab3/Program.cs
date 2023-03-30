namespace Lab3;

public static class Program
{
    private static EventManager _eventManager = new EventManager();
    
    public static void Main()
    {
        Console.WriteLine("1. Add\n" +
                          "2. Remove\n" +
                          "3. Edit\n" +
                          "4. Look all\n" +
                          "5. Find event\n" +
                          "6. Add Range");

        var task = ParseNumber();

        switch (task)
        {
            case 1:
                Console.WriteLine("1 - Single Event\n" +
                                  " 2 - Repeated Event\n");
                var variant = ParseNumber();
                _eventManager.Add(variant == 1
                    ? SingleEvent.CreateFromKeyboard<SingleEvent>()
                    : RepeatedEvent.CreateFromKeyboard<RepeatedEvent>());
                break;
            case 2:
                if (_eventManager.Count == 0)
                {
                    Console.WriteLine("EventManager is empty!");
                    break;
                }

                Console.WriteLine("Input index: ");
                var index = ParseNumber();
                while (index > _eventManager.Count)
                    index = ParseNumber();

                _eventManager.Remove(index);
                
                break;
            case 3:
                Console.WriteLine("Input title");
                var inputTitle = Console.ReadLine();
                while (inputTitle is null)
                    inputTitle = Console.ReadLine();

                var item = _eventManager.Find(inputTitle);
                if (item is null)
                    Console.WriteLine("No such item in manager");
                else
                    item.EditFromKeyboard();
                break;
            case 4:
                for (var i = 0; i < _eventManager.Count; i++)
                    Console.WriteLine($"{i}: {_eventManager[i].Print()}");
                break;
            case 5:
                Console.Write("Input Date: ");
                var date = SomeEvent<object>.ParseData();

                Console.WriteLine("Event at this day:\n");
                foreach (var someEvent in _eventManager.Find(date))
                {
                    if(someEvent is SingleEvent tempSingleEvent)
                        Console.WriteLine(tempSingleEvent.Print() + "\n------");
                    else
                        Console.WriteLine((someEvent as RepeatedEvent).Print() + "\n------");
                }

                break;
            case 6:
                if (_eventManager.Count == 0)
                {
                    Console.WriteLine("EventManager is empty!");
                    break;
                }
                Console.WriteLine("Input copied index");
                var tempIndex = 0;
                var inputIndex = Console.ReadLine();
                while (!int.TryParse(inputIndex, out tempIndex))
                    inputIndex = string.Empty;

                if (_eventManager.Count < tempIndex)
                {
                    Console.WriteLine($"Index too big, in event manager only {_eventManager.Count} items");
                    break;
                }
                
                inputIndex = string.Empty;
                Console.WriteLine("Input count");
                var tempCount = 0;
                while (!int.TryParse(inputIndex, out tempCount))
                    inputIndex = Console.ReadLine();
                
                var tempNode = _eventManager[tempIndex] as SingleEvent;
                if (tempNode != null)
                    _eventManager.AddRange(tempNode, tempCount);
                else
                    _eventManager.AddRange(_eventManager[tempIndex] as RepeatedEvent, tempCount);                        
                break;
        }

        Main();
    }
    
    public static int ParseNumber(string i = "")
    {
        Console.WriteLine(i);
        var input = Console.ReadLine();
        var task = 0;
        while(!int.TryParse(input, out task) && (task is > 0 and < 5))
            input = Console.ReadLine();

        return task;
    }
}