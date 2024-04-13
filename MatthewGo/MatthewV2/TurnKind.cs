namespace MatthewV2;

public class TurnKind : Command
{
    public TurnKind(Matthew receiver) : base(receiver)
    {
    }

    public override void ChangeState()
    {
        receiver.Neuro = new KindMatthew();
    }

}
