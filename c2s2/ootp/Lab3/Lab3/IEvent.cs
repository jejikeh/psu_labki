namespace Lab3;

public interface IEvent
{
    public string Title { get; }
    public IEvent Copy(IEvent source);
    public IEvent EditFromKeyboard();

}