namespace Lab5;

public class RepeatedEvent : SomeEvent<List<DateTime>>
{
    private int _countEvents;
    
    public RepeatedEvent()
    {
        Date = new List<DateTime>();
    }
    
    ~RepeatedEvent()
    {
        Console.WriteLine($"{Title} destructor was called of {GetType().Name}");
    }
    
    public override string Print()
    {
        var table = Date.Aggregate(string.Empty, (current, dateTime) => current + ("\t* " + dateTime + "\n"));
        return $"\nTitle:\n  \t{Title}\n Date:\n DateTable:\n {table}\n";
    }

    public override IEvent Copy(IEvent source)
    {
        if (source is RepeatedEvent repeatedEvent)
        {
            Title = repeatedEvent.Title;
            Date = repeatedEvent.Date;
            _countEvents = repeatedEvent._countEvents;
            Date = repeatedEvent.Date;
        }

        return this;
    }

    protected sealed override void EditUniqueFields()
    {
        Console.WriteLine("Input repeated times: ");
        var inputString = Console.ReadLine();
        while (!int.TryParse(inputString, out _countEvents))
            inputString = Console.ReadLine();

        for(var i = 0; i < _countEvents; i++)
            Date.Add(ParseData());
    }
}