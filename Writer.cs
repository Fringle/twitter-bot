using System;
namespace TwitterBot
{
    public class Writer : Interfaces.IWriter
    {
        private const int twitterLimitLength = 285;
        private int tweetLength;

        public Writer(Interfaces.ITweetConfig config)
        {
            Console.WriteLine("Writer(config)");
            this.tweetLength = 
                config.TweetLength > twitterLimitLength || config.TweetLength < 1 ? twitterLimitLength : config.TweetLength;
        }
    }
}
