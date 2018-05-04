using System;
using System.Linq;
using System.Collections.Generic;
namespace TwitterBot
{
    /*
     * Конкретный писатель, который составляет статистику по тексту,
     * а затем создает сообщения необходимой длины.
     * По совместительсту публикует статистику в консоль.
     */
    public class StatisticsWriter : Interfaces.IWriter
    {
        TweetsReceiver receiver;
        TwitterConfig config;
        List<string> posts;

        const int precision = 5; // колличество цифр после запятой в статистике

        public StatisticsWriter(TwitterConfig config, TweetsReceiver receiver)
        {
            this.config = config;
            this.receiver = receiver;
        }

        public List<string> Posts {
            get { return posts; }
        }

        public void WritePosts(){
            string textLastTweets = receiver.Data;

            Dictionary<char,double> statistic = GetStatistic(textLastTweets);

            WriteStatisticInConsole(statistic);

            posts = CreatePosts(statistic);
        }

        Dictionary<char, double> GetStatistic(string text){
            Dictionary<char, double> statistic = new Dictionary<char, double>();

            if(text.Equals("")){
                return statistic;
            }

            // Преобразуем все буквы к маленьким
            text = text.ToLower();

            // Оставляем только только буквенные значения
            text = new string(text.Where(x => char.IsLetter(x)).ToArray());

            // Создаем ассоциативный массив 'буква' => 'количество её повторений'
            Dictionary<char,int> charCounts = text.OrderByDescending(x => x).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());

            int count = text.Length;

            // Рассчитываем долю содержания каждой буквы 
            foreach(KeyValuePair<char,int> pair in charCounts){
                double proportion = Math.Round((double)pair.Value / count, precision); //
                statistic.Add(pair.Key, proportion);
            }

            return statistic;
        }

        void WriteStatisticInConsole(Dictionary<char,double> statistic){
            string statisticMessage = "@" + receiver.Name + ", статистика для последних " + config.TweetsCount + " твитов:\n{";
            Console.WriteLine(statisticMessage);
            foreach(KeyValuePair<char,double> pair in statistic){
                Console.WriteLine("'{0}' : {1}", pair.Key, pair.Value.ToString().Replace(",", "."));
            }
            Console.WriteLine("}");
        }

        // Метод для формирования твитов
        List<string> CreatePosts(Dictionary<char,double> statistic){
            List<string> finalPosts = new List<string>();

            Stack<string> jsonStatistic = GetJsonStatistic(statistic);

            // Каждый твит будет начинаться с необходимого сообщения
            string statisticMessage = "@" + receiver.Name + ", статистика для последних " + config.TweetsCount + " твитов:\n{";
            string postText = statisticMessage;

            while(jsonStatistic.Count != 0){
                // Добавляем в сообщение статистику, пока помещается,
                // если не помещается, добавляем соощение в лист твитов и создаем новое сообщение 
                 if (postText.Length + jsonStatistic.Peek().Length + 1 <= config.TweetLength)
                {
                    postText += postText.EndsWith("{") ? jsonStatistic.Pop() : "," + jsonStatistic.Pop();
                }
                else
                {
                    postText += "}";
                    finalPosts.Add(postText);
                    postText = statisticMessage;
                }
            }

            postText += "}";
            finalPosts.Add(postText);

            return finalPosts;
        }

        // Создает JSON представление для каждой буквы и её доли содержания
        Stack<string> GetJsonStatistic(Dictionary<char,double> statistic){
            Stack<string> jsonStatistic = new Stack<string>();
            foreach (KeyValuePair<char, double> pair in statistic)
            {
                string letterStatistic = " \"" + pair.Key + "\" : " + pair.Value.ToString().Replace(",", ".");
                jsonStatistic.Push(letterStatistic);
            }
            return jsonStatistic;
        }
    }
}
