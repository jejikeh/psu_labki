namespace Lab1;

public class SomeEvent
{
    public string Title { get; private set; } = string.Empty;
    public DateTime Date { get; private set; }  

    public override string ToString()
    {
        return $"Title: {Title} Date: {Date.Date}";
    }

    public static SomeEvent CreateFromKeyboard()
    {
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title == string.Empty)
            title = Console.ReadLine();
        
        Console.Write("Input Date title: ");
        DateTime date;
        var input = Console.ReadLine();
        while (!DateTime.TryParse(input, out date))
            input = Console.ReadLine();


        return new SomeEvent()
        {
            Title = title,
            Date = date
        };
    }
    
    public SomeEvent EditFromKeyboard()
    {
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title is null)
            title = Console.ReadLine();
        
        Console.Write("Input Date: ");
        DateTime date;
        var input = Console.ReadLine();
        while (!DateTime.TryParse(input, out date))
            input = Console.ReadLine();

        Date = date;
        Title = title;
        return this;
    }
}