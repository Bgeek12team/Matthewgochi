namespace Matthew;

// инициатор команды
public class Invoker
{
    Command command;
    public void SetCommand(Command c)
    {
        command = c;
    }
    public string Run()
    {
        return command.Execute();
    }
}