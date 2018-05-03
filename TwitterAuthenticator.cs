using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TwitterAuthenticator : Interfaces.IAuth
    {
        public void Auth(Interfaces.IAuthConfig config){
            Console.WriteLine("Auth()");
            Tweetinvi.Auth.SetUserCredentials(config.ConsumerKey,
                                              config.ConsumerSecret,
                                              config.AccessToken,
                                              config.AccessTokenSecret);
            
            var authenticatedUser = User.GetAuthenticatedUser();
            if(authenticatedUser == null){
                throw new Exception("Пользователь не авторизован. Проверьте правильность авторизационных данных.");
            }
        }
    }
}
