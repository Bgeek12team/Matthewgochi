using gigaMatthew;

namespace Matthew;

public class PlayCommand : Command
{
    Matthew receiver;
    static Adapter adapter = new Adapter();
    
    public PlayCommand(Matthew r, string query) : base(query)
    {
        receiver = r;
    }
    public override async Task<string> Execute()
    {
        return await adapter.Execute(Query);
        
    }

}