using gigaMatthew;
namespace MatthewV2;

public class Client
{
    private Matthew _matthew;
    private Invoker _invoker;
    public event EventHandler TurnedEvil;
    public event EventHandler TurnedKind;

    public Client() { _matthew = new(); _invoker = new(); }
    public void Feed(int amount) => _matthew.Feed(amount);

    public async Task<string> Ask(string question, int askCost)
    {
        _matthew.Move(askCost);
        if (_matthew.SoulState < 0)
        {
            TurnedEvil?.Invoke(this, new EventArgs());
            _invoker.Command = new TurnEvil(_matthew);
        }
        else
        {
            TurnedKind?.Invoke(this, new EventArgs());
            _invoker.Command = new TurnKind(_matthew);
        }

        _invoker.Execute();
        return await _matthew.Ask(question);
    }
}
