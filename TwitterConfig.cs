using System;
using System.Configuration;
namespace TwitterBot
{
    public class TwitterConfig : Interfaces.IAuthConfig
    {
        private string _ConsumerKey, _ConsumerSecret, _AccessToken, _AccessTokenSecret;
        private int _TweetLenght, _TweetsCount;
        private const int TwitterLimitLength = 280;
        private const int TweetinviMaxTweets = 40;

        public TwitterConfig()
        {
            Console.WriteLine("Config()");
            this._ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            this._ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            this._AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            this._AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            this._TweetLenght = TwitterLimitLength;
                
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["TweetsCount"], 10);
            this._TweetsCount = count > TweetinviMaxTweets || count < 1 ? TweetinviMaxTweets : count;
        }

        public string ConsumerKey{
            get { return this._ConsumerKey; }
        }

        public string ConsumerSecret{
            get { return this._ConsumerSecret; }
        }

        public string AccessToken
        {
            get { return this._AccessToken; }
        }

        public string AccessTokenSecret
        {
            get { return this._AccessTokenSecret; }
        }

        public int TweetLength
        {
            get { return this._TweetLenght; }
        }

        public int TweetsCount
        {
            get { return this._TweetsCount; }
        }
    }
}
