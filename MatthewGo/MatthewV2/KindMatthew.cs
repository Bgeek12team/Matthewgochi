using gigaMatthew;

namespace MatthewV2;

public class KindMatthew : IANeuroAnswer
{
    Adapter adapter = new Adapter();
    public async Task<string> GetAnswer(string question) =>
        await adapter.Execute(question);
}
