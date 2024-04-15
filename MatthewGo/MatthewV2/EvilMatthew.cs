using gigaMatthew;

namespace MatthewV2;

public class EvilMatthew : IANeuroAnswer
{
    Adapter adapter = new Adapter();
    public async Task<string> GetAnswer(string question) =>
        await adapter.Execute("Отвечай так, будто у тебя выдался неудачный день. " + question);
}
