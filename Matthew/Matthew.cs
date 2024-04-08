namespace Matthew;

// получатель команды
public class Matthew
{
    public double SoulState { get; private set; } = 0;
    public void Feed(double amount) =>
        SoulState+=amount;

    public void WasteEnergy(double amount) =>
        SoulState-=amount;

    public MathewState GetState() =>
        new(SoulState); 

    public void RestoreState(MathewState mathewState) =>
        SoulState = mathewState.SoulState;

}
