namespace MatthewV2;

public abstract class Command
{
    protected Matthew receiver;

    public Command(Matthew receiver) => this.receiver = receiver;

    public abstract void ChangeState(); 
}
