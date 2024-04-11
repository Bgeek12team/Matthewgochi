using gigaMatthew;

namespace Matthew;

public class PlayCommand : Command
{
    Matthew receiver;
    public PlayCommand(Matthew r, string query) : base(query)
    {
        receiver = r;
    }
    public override string Execute()
    {
        return Adapter.execute(Query).ToString();
        
    }

}