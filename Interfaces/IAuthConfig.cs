using System;
namespace TwitterBot.Interfaces
{
    /*
     * В основном в соц. сетях используют только ConsumerKey и ConsumerSecret для авторизации приложения,
     * для авторизации пользователя необходимы ещё AccessToken и AccessTokenSecret
     */
    public interface IAuthConfig
    {
        string ConsumerKey{
            get;
        }

        string ConsumerSecret
        {
            get;
        }

        string AccessToken
        {
            get;
        }

        string AccessTokenSecret
        {
            get;
        }
    }
}
