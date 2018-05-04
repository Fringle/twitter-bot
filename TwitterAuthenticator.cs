using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TwitterAuthenticator : Interfaces.IAuth
    {
        /*
         * Конкретный авторизатор для соц. сети Twitter'a
         */
        public void Auth(Interfaces.IAuthConfig config){
            Tweetinvi.Auth.SetUserCredentials(config.ConsumerKey,
                                              config.ConsumerSecret,
                                              config.AccessToken,
                                              config.AccessTokenSecret);
            
            var authenticatedUser = User.GetAuthenticatedUser();
            if(authenticatedUser == null){
                // Необходимо прекратить выполнение программы, если не удалось авторизоваться
                throw new Exception("Пользователь не авторизован. Проверьте правильность авторизационных данных.");
            }
        }
    }
}
