using System;
namespace TwitterBot
{
    public class StatisticsWriter : Interfaces.IWriter
    {
        private const int twitterLimitLength = 285;
        private int tweetLength;

        public StatisticsWriter(TwitterConfig config)
        {
            Console.WriteLine("Writer(config)");
            this.tweetLength = 
                config.TweetLength > twitterLimitLength || config.TweetLength < 1 ? twitterLimitLength : config.TweetLength;
        }

        public void WritePosts(){
            Console.WriteLine("Write()");
        }
    }
}
