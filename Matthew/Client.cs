namespace Matthew;

public class Client
{
    Matthew matthew = new Matthew();
    Invoker invoker = new Invoker();    
    MatthewHistory history = new MatthewHistory();


    public string Feed(string amount)
    {
        var command = new FeedCommand(matthew, amount);
        return Exec(command);
    }

    public string Play(string query)
    {
        var command = new PlayCommand(matthew, query);
        return Exec(command);
    }
 
    public void Undo()
    {
        matthew.RestoreState(history.History.Pop());
    }


    string Exec(Command command)
    {
        history.History.Push(matthew.GetState());
        invoker.SetCommand(command);
        return invoker.Run();
    }
}
