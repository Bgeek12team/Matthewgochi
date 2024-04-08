namespace Matthew;

public abstract class Command
{
    public string Query { get; set; }
    public Command(string query)
    {
        Query = query;
    }
    public abstract string Execute();
}
