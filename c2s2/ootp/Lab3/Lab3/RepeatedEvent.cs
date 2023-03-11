namespace Lab3;

public class SingleEvent : SomeEvent
{
    public decimal Budget;

    protected override void EditUniqueFields()
    {
        Console.WriteLine("Input budget: ");
        var inputString = string.Empty;
        while (decimal.TryParse(inputString, out Budget))
            inputString = Console.ReadLine();
    }
}