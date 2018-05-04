using System;
using Tweetinvi;
namespace TwitterBot
{
    /*
     * Конкретный получатель. Получает текст последних твитов определенного пользователя Twitter'a.
     */
    public class TweetsReceiver : Interfaces.IReceiver
    {
        string _data = "", _name = "";
        TwitterConfig config;

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
            _name = data[0];

            var user = User.GetUserFromScreenName(_name);

            // Если заданный пользователь не найден выбрасываем исключения, для нового ввода данных
            if(user == null){
                throw new Exception("Пользователь не найден.");
            }

            var tweets = Timeline.GetUserTimeline(_name, config.TweetsCount);

            // Необходимо обновлять текст твитов
            _data = "";

            if(tweets == null){
                return;
            }

            foreach(var tweet in tweets){
                _data += tweet.Text;
            }
        }
    }
}
