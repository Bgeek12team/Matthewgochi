using GigaChatAdapter;

namespace gigaMatthew
{
    public static class Adapter
    {
        private static string authData = "MWYyYjhjMmUtNjJmYi00MTY5LWI2NmUtOTJhM2YyNDAwOTkwOjQ4YTVkZDJjLTBiM2EtNDBiZi1hYjk5LTg0MjcxNzQ5NTg1Yg==";
        private static Authorization auth;

        static Adapter()
        {
            auth = new Authorization(authData, GigaChatAdapter.Auth.RateScope.GIGACHAT_API_PERS);
        }

        public async static Task<string> execute(string prompt)
        {
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
                        return string.Join(' ', result.GigaChatCompletionResponse.Choices.Select(c => c.Message));
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
