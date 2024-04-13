namespace MatthewV2;

public class Matthew
{
    public IANeuroAnswer Neuro { get; set; }

    public int SoulState { get; private set; } = 0;

    public Matthew(IANeuroAnswer neuro) => Neuro = neuro;

    public Matthew() { }

    public void Feed(int amount) => SoulState += amount;

    public void Move(int  amount) => SoulState -= amount;

    public async Task<string> Ask(string question) => await Neuro.GetAnswer(question);

}
