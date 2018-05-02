using System;
using System.Configuration;
namespace TwitterBot
{
    public class TwitterConfig : Interfaces.IAuthConfig
    {
        private string _ConsumerKey, _ConsumerSecret, _AccessToken, _AccessTokenSecret;
        private int _TweetLenght, _TweetsCount;
        private string _InputData;

        public TwitterConfig()
        {
            Console.WriteLine("Config()");
            this._ConsumerKey = System.Configuration.ConfigurationManager.AppSettings["ConsumerKey"];
            this._ConsumerSecret = System.Configuration.ConfigurationManager.AppSettings["ConsumerSecret"];
            this._AccessToken = System.Configuration.ConfigurationManager.AppSettings["AccessToken"];
            this._AccessTokenSecret = System.Configuration.ConfigurationManager.AppSettings["AccessTokenSecret"];

            this._TweetLenght = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TweetLength"], 10);
            this._TweetsCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TweetsCount"], 10);

            this._InputData = System.Configuration.ConfigurationManager.AppSettings["InputData"];
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

        public string InputData
        {
            get { return this._InputData; }
        }

    }
}
