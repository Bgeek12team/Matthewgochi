namespace MatthewV2;

public class TurnEvil : Command
{
    public TurnEvil(Matthew receiver) : base(receiver)
    {
    }

    public override void ChangeState()
    {
        receiver.Neuro = new EvilMatthew();
    }

}
