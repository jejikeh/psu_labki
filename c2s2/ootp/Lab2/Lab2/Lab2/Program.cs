namespace Lab1;

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

        {
            new SomeEvent();
        }

        switch (task)
        {
            case 1:
                _eventManager.Add(SomeEvent.CreateFromKeyboard());
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
                Console.WriteLine("Destructor of SomeEvent was called!");
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
                    Console.WriteLine($"{i}: {_eventManager[i]}");
                break;
            case 5:
                Console.Write("Input Date: ");
                DateTime date;
                var inputDate = Console.ReadLine();
                while (!DateTime.TryParse(inputDate, out date))
                    inputDate = Console.ReadLine();

                Console.WriteLine("Event at this day:\n");
                foreach (var someEvent in _eventManager.Find(date))
                    Console.WriteLine(someEvent + "\n------");
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
                
                _eventManager.AddRange(_eventManager[tempIndex], tempCount);
                break;
        }

        Main();
    }
    
    private static int ParseNumber()
    {
        var input = Console.ReadLine();
        var task = 0;
        while(!int.TryParse(input, out task) && (task is > 0 and < 5))
            input = Console.ReadLine();

        return task;
    }
}