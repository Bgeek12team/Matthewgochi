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
        if (double.TryParse(Query, out var amount))
        {
            receiver.WasteEnergy(amount);
            return Adapter.execute(Query).ToString();
        }
        return "Incorrect Command";
    }

}