using GigaChatAdapter;

namespace gigaMatthew
{
    public class Adapter
    {
        private string authData = "MDc3OTcyMzYtZjAxNS00NDBiLTkxMzUtZTk2NWE4NDQ5MDI3OjRjN2EzZTljLWExZWMtNDA2ZC05YTUxLTdjYzMzZjUxMzU2Zg==";
        private Authorization auth;


        public async Task<string> Execute(string prompt)
        {
            auth = new Authorization(authData, GigaChatAdapter.Auth.RateScope.GIGACHAT_API_PERS);
            var authResult = await auth.SendRequest();

            if (authResult.AuthorizationSuccess)
            {
                Completion completion = new Completion();

                while (true)
                {
                    //Обновление токена, если он просрочился
                    await auth.UpdateToken();

                    //Отправка промпта (с историей)
                    var result = await completion.SendRequest(auth.LastResponse.GigaChatAuthorizationResponse?.AccessToken, prompt, true);

                    if (result.RequestSuccessed)
                    {
                        return result.GigaChatCompletionResponse.Choices.LastOrDefault().Message.Content;
                    }
                    else
                    {
                        return "Error";
                    }
                }
            }
            else
            {
                return "Error";
            }
        }
    }
}
