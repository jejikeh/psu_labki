namespace Lab3;

public class SingleEvent : SomeEvent<DateTime>
{
    public decimal Budget;

    public override IEvent Copy(IEvent source)
    {
        if (source is SingleEvent singleEvent)
        {
            Title = singleEvent.Title;
            Date = singleEvent.Date;
            Budget = singleEvent.Budget;
        }

        return this;
    }

    ~SingleEvent()
    {
        Console.WriteLine($"{Title} destructor was called of {GetType().Name}");
    }

    public SingleEvent(string title, DateTime date, decimal budget) : base(title, date)
    {
        Budget = budget;
    }

    public SingleEvent()
    {
    }

    public override string ToString()
    {
        return $"\nTitle:\n  \t{Title}\n Date:\n \t{Date}\n Budget:\n \t{Budget}\n Organisator: {Organisation} MaxTicket {MaxTickets}";
    }

    protected sealed override void EditUniqueFields()
    {
        Date = ParseData();

        Console.WriteLine("Input budget: ");
        var inputString = Console.ReadLine();
        while (!decimal.TryParse(inputString, out Budget) && Budget <= 0)
            inputString = Console.ReadLine();
    }
}