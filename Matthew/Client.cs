﻿namespace Matthew;

public class Client
{
    Matthew matthew = new Matthew();
    Invoker invoker = new Invoker();    
    MatthewHistory history = new MatthewHistory();


    public async Task<string> Feed(string amount)
    {
        var command = new FeedCommand(matthew, amount);
        return await Exec(command);
    }

    public async Task<string> Play(string query)
    {
        var command = new PlayCommand(matthew, query);
        return await Exec(command);
    }
 
    public void Undo()
    {
        matthew.RestoreState(history.History.Pop());
    }


    async Task<string> Exec(Command command)
    {
        history.History.Push(matthew.GetState());
        invoker.SetCommand(command);
        return await invoker.Run();
    }
}
