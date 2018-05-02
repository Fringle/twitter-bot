using System;
namespace TwitterBot.Interfaces
{
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
