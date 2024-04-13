namespace MatthewV2;

public class Invoker
{
    public Command Command
    {
        get; set;
    }

    public Invoker(Command command) => Command = command;

    public Invoker() { }

    public void Execute() => Command.ChangeState();
}
