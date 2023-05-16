namespace Lab5;

public interface IEvent
{
    public string Title { get; }
    public IEvent Copy(IEvent source);
    public IEvent EditFromKeyboard();
    public string Print();

    public static IEvent CreateEmptyObject()
    {
        return new SingleEvent();
    }
}