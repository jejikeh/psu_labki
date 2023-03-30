using System.Globalization;

namespace Lab1;

public class SomeEvent
{
    public string Title { get; private set; }
    public DateTime Date { get; private set; }

    public SomeEvent()
    {
        Title = "unset";
        Date = DateTime.Today;
        Console.WriteLine($"{Title} empty constructor was was called");
    }

    public SomeEvent(SomeEvent someEvent)
    {
        Title = someEvent.Title;
        Date = someEvent.Date;
        Console.WriteLine($"{Title} copy constructor was was called");
    }

    public SomeEvent(string title, DateTime date)
    {
        Title = title;
        Date = date;
        Console.WriteLine($"{Title} constructor with parameters was was called");
    }

    ~SomeEvent()
    {
        Console.WriteLine($"{Title} destructor was called");
        Title = "";
        Date = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Title: {Title} Date: {Date}";
    }

    public static SomeEvent CreateFromKeyboard()
    {
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title == string.Empty)
            title = Console.ReadLine();
        
        Console.Write("Input Date title in style mm/dd/yy hh:mm:ss: ");
        DateTime date;
        var input = Console.ReadLine();
        while (!DateTime.TryParseExact(input, "G",CultureInfo.InvariantCulture,DateTimeStyles.None, out date))
            input = Console.ReadLine();


        return new SomeEvent(title, date);
    }
    
    public SomeEvent EditFromKeyboard()
    {
        Console.Write("Input Event title: ");
        var title = Console.ReadLine();
        while (title is null)
            title = Console.ReadLine();
        
        Console.Write("Input Date title in style mm/dd/yy hh:mm:ss: ");
        DateTime date;
        var input = Console.ReadLine();
        while (!DateTime.TryParseExact(input, "G",CultureInfo.InvariantCulture, DateTimeStyles.None,out date))
            input = Console.ReadLine();

        Date = date;
        Title = title;
        return this;
    }
}