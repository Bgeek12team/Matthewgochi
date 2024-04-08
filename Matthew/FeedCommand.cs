namespace Matthew;

// конкретная команда
public class FeedCommand : Command
{
    Matthew receiver;
    public FeedCommand(Matthew r, string query) : base(query)
    {
        receiver = r;
    }
    public override string Execute()
    {
        if (double.TryParse(Query, out var amount))
        {
            receiver.Feed(amount);
            return "Success! Mathew dovolen";
        }
        return "Incorrect Command";
    }

}
