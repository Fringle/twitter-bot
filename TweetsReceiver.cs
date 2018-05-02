using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TweetsReceiver : Interfaces.IReceiver
    {
        private TwitterConfig config;

        public TweetsReceiver(TwitterConfig config)
        {
            this.config = config;
        }

        public void Receive(string[] data){
            string name = data[0];
            Console.WriteLine("Receive({0})", name);
            var tweets = Timeline.GetUserTimeline(name, this.config.TweetsCount);
        }
    }
}
