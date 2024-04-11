namespace Matthew;

// инициатор команды
public class Invoker
{
    Command command;
    public void SetCommand(Command c)
    {
        command = c;
    }
    public async Task<string> Run()
    {
        return await command.Execute(); 
    }
}