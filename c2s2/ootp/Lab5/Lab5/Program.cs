namespace Lab5;

public static class Program
{
    private static EventManager _eventManager = new EventManager();
    private static GenericEventManager<SingleEvent, DateTime> _singleEventManager = new GenericEventManager<SingleEvent, DateTime>();

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("1. Add\n" +
                              "2. Remove\n" +
                              "3. Edit\n" +
                              "4. Look all\n" +
                              "5. Find event\n" +
                              "6. Add Range\n" +
                              "7. Compare same items\n" +
                              "8. Compare <\n" +
                              "9. Add to generic list\n" +
                              "10. Print all generic items\n" +
                              "11. Find()\n" +
                              "12. Sort()\n" +
                              "13. Min()\n" +
                              "14. Max()");

            var task = ParseNumber();

            try
            {
                switch (task)
                {
                    case 1:
                        AddTask();
                        break;
                    case 2:
                        RemoveTask();
                        break;
                    case 3:
                        EditTask();
                        break;
                    case 4:
                        LookAllTask();
                        break;
                    case 5:
                        FindTask();
                        break;
                    case 6:
                        AddRangeTask();
                        break;
                    case 7:
                        CompareSameItemsTask();
                        break;
                    case 8:
                        CompareTask();
                        break;
                    case 9:
                        _singleEventManager += (SingleEvent)SingleEvent.CreateFromKeyboard<SingleEvent>();
                        break;
                    case 10:
                        PrintAllGenericItemsTask();

                        break;
                    case 11:
                        var indexOfTheSingleElement = ParseNumberWithException("Input the index of the element", 0, _singleEventManager.Count());
                        Console.WriteLine($"{_singleEventManager.Find((SingleEvent)_singleEventManager[indexOfTheSingleElement])}");
                        break;
                    case 12:
                        var sortedEvents = _singleEventManager.Sort();
                        foreach (var some in sortedEvents)
                            Console.WriteLine($"{some.Print()} \n -------- \n");
                        break;
                    case 13:
                        Console.WriteLine($"{_singleEventManager.Min().Print()}");
                        break;
                    case 14:
                        Console.WriteLine($"{_singleEventManager.Max().Print()}");
                        break;
                }
            }
            catch (Exception ex)
            {
                var colorBefore = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"The exception was thrown: {ex.Message}");
                Console.ForegroundColor = colorBefore;
            }
        }
    }

    private static void PrintAllGenericItemsTask()
    {
        for (var i = 0; i < _singleEventManager.Count; i++)
        {
            Console.WriteLine($"{i}: ");
            _ = _singleEventManager << i;
        }
    }

    private static void CompareTask()
    {
        var firstElementIndex = ParseNumberWithException("Input the first element index", 0, _eventManager.Count());
        while (firstElementIndex > _eventManager.Count() - 1)
            firstElementIndex = ParseNumber("Input the first element index", 0, _eventManager.Count());

        var secondElementIndex = ParseNumberWithException("Input the second element index", 0, _eventManager.Count());
        while (secondElementIndex > _eventManager.Count() - 1)
            secondElementIndex = ParseNumberWithException("Input the second element index", 0, _eventManager.Count());

        var firstElement = _eventManager[firstElementIndex];
        var secondElement = _eventManager[secondElementIndex];

        var singleEvent = firstElement as SingleEvent;
        var singleElement = secondElement as SingleEvent;
        if (singleEvent is not null && singleElement is not null)
        {
            // 1item > 2item : true/false
            // vice versa
            Console.WriteLine(
                $"The first is more than the second element?: {singleEvent > singleElement}");
            return;
        }

        var repeatedEvent = firstElement as RepeatedEvent;
        var repeatedElement = secondElement as RepeatedEvent;
        if (repeatedElement is not null && repeatedEvent is not null)
            Console.WriteLine(
                $"The first is more than the second element? : {repeatedEvent > repeatedElement}");
    }

    private static void CompareSameItemsTask()
    {
        if (_eventManager.Count < 1)
        {
            Console.WriteLine("The are no items");
            return;
        }

        var head = _eventManager[0];
        Console.WriteLine($"Should be true: {head == _eventManager[0]}");
    }

    private static void AddRangeTask()
    {
        if (_eventManager.Count == 0)
            throw new EmptyListException("The EventManager is empty");

        Console.WriteLine("Input copied index");
        var tempIndex = 0;
        var inputIndex = Console.ReadLine();
        while (!int.TryParse(inputIndex, out tempIndex)) inputIndex = string.Empty;

        if (_eventManager.Count < tempIndex)
        {
            Console.WriteLine($"Index too big, in event manager only {_eventManager.Count} items");
            return;
        }

        inputIndex = string.Empty;
        Console.WriteLine("Input count");
        var tempCount = 0;
        while (!int.TryParse(inputIndex, out tempCount)) inputIndex = Console.ReadLine();

        var tempNode = _eventManager[tempIndex] as SingleEvent;
        if (tempNode != null)
            _eventManager.AddRange(tempNode, tempCount);
        else
            _eventManager.AddRange(_eventManager[tempIndex] as RepeatedEvent, tempCount);
    }

    private static void FindTask()
    {
        Console.Write("Input Date: ");
        var date = SomeEvent<object>.ParseData();

        Console.WriteLine("Event at this day:\n");
        foreach (var someEvent in _eventManager.Find(date))
        {
            if (someEvent is SingleEvent tempSingleEvent)
                Console.WriteLine(tempSingleEvent.Print() + "\n------");
            else
                Console.WriteLine((someEvent as RepeatedEvent)?.Print() + "\n------");
        }
    }

    private static void LookAllTask()
    {
        for (var i = 0; i < _eventManager.Count; i++)
        {
            Console.WriteLine($"{i}: ");
            _ = _eventManager << i;
        }
    }

    private static void EditTask()
    {
        Console.WriteLine("Input title");
        var inputTitle = Console.ReadLine();
        while (inputTitle is null) inputTitle = Console.ReadLine();

        var item = _eventManager.Find(inputTitle);
        if (item is null)
            Console.WriteLine("No such item in manager");
        else
            item.EditFromKeyboard();
    }

    private static void RemoveTask()
    {
        if (_eventManager.Count == 0)
        {
            Console.WriteLine("EventManager is empty!");
            return;
        }

        Console.WriteLine("Input index: ");
        var index = ParseNumber();
        while (index > _eventManager.Count) index = ParseNumber();

        _eventManager.Remove(index);
    }

    private static void AddTask()
    {
        Console.WriteLine("1 - Single Event\n" + " 2 - Repeated Event\n");
        var variant = ParseNumber();

        if (variant == 1)
            _eventManager += SingleEvent.CreateFromKeyboard<SingleEvent>();
        else
            _eventManager += RepeatedEvent.CreateFromKeyboard<RepeatedEvent>();
    }

    public static int ParseNumber(string i = "", int min = 0, int max = 5)
    {
        Console.WriteLine(i);
        var input = Console.ReadLine();
        var task = 0;
        while(!int.TryParse(input, out task) && (task > min && task < max))
            input = Console.ReadLine();

        return task;
    }
    
    public static int ParseNumberWithException(string i = "", int min = 2, int max = 5)
    {
        Console.WriteLine(i);
        var input = Console.ReadLine();
        var task = 0;
        while(!int.TryParse(input, out task))
            input = Console.ReadLine();

        if (task < min || task > max)
            throw new ArgumentOutOfRangeException(nameof(task));

        return task;
    }
}