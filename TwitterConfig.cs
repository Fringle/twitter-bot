using System;
using System.Configuration;
namespace TwitterBot
{
    /*
     * Объект конфига для считывания конфигурационного файла
     */
    public class TwitterConfig : Interfaces.IAuthConfig
    {
        string _ConsumerKey, _ConsumerSecret, _AccessToken, _AccessTokenSecret;
        int _TweetLenght, _TweetsCount;
        const int TwitterLimitLength = 280; // Ограничение длины сообщения твита
        const int TweetinviMaxTweets = 40;  // Ограничение получения твитов, задано Tweetinvi

        public TwitterConfig()
        {
            _ConsumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            _ConsumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            _AccessToken = ConfigurationManager.AppSettings["AccessToken"];
            _AccessTokenSecret = ConfigurationManager.AppSettings["AccessTokenSecret"];

            _TweetLenght = TwitterLimitLength;
                
            int count = Convert.ToInt32(ConfigurationManager.AppSettings["TweetsCount"], 10);
            _TweetsCount = count > TweetinviMaxTweets || count < 1 ? TweetinviMaxTweets : count;
        }

        public string ConsumerKey{
            get { return _ConsumerKey; }
        }

        public string ConsumerSecret{
            get { return _ConsumerSecret; }
        }

        public string AccessToken
        {
            get { return _AccessToken; }
        }

        public string AccessTokenSecret
        {
            get { return _AccessTokenSecret; }
        }

        public int TweetLength
        {
            get { return _TweetLenght; }
        }

        public int TweetsCount
        {
            get { return _TweetsCount; }
        }
    }
}
