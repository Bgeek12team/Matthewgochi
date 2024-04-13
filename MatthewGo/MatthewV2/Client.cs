using gigaMatthew;
namespace MatthewV2;

public class Client
{
    private Matthew _matthew;
    private Invoker _invoker;
    private const int ASK_COST = 1;

    public Client() { _matthew = new(); _invoker = new(); }
    public void Feed(int amount) => _matthew.Feed(amount);

    public async Task<string> Ask(string question)
    {
        _matthew.Move(ASK_COST);
        if (_matthew.SoulState < 0)
        {
            _invoker.Command = new TurnEvil(_matthew);
        }
        else
        {
            _invoker.Command = new TurnKind(_matthew);
        }

        _invoker.Execute();
        return await _matthew.Ask(question);
    }
}
