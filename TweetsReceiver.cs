using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TweetsReceiver : Interfaces.IReceiver
    {
        private string _data = "";
        private TwitterConfig config;

        public TweetsReceiver(TwitterConfig config)
        {
            this.config = config;
        }

        public string Data{
            get { return _data; }
        }

        public void Receive(string[] data){
            string name = data[0];
            Console.WriteLine("Receive({0})", name);

            var tweets = Timeline.GetUserTimeline(name, this.config.TweetsCount);

            foreach(var tweet in tweets){
                this._data += tweet.Text;
            }
        }
    }
}
