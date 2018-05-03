using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TweetsReceiver : Interfaces.IReceiver
    {
        private string _data = "", _name = "";
        private TwitterConfig config;

        public TweetsReceiver(TwitterConfig config)
        {
            this.config = config;
        }

        public string Data{
            get { return _data; }
        }

        public string Name{
            get { return _name; }
        }

        public void Receive(string[] data){
            this._name = data[0];
            Console.WriteLine("Receive({0})", this._name);

            var user = User.GetUserFromScreenName(this._name);

            if(user == null){
                throw new Exception("Не смогли найти такого пользователя");
            }

            var tweets = Timeline.GetUserTimeline(this._name, this.config.TweetsCount);

            if(tweets == null){
                return;
            }

            foreach(var tweet in tweets){
                this._data += tweet.Text;
            }
        }
    }
}
