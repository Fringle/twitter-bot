using System;
using System.Linq;
using System.Collections.Generic;
namespace TwitterBot
{
    public class StatisticsWriter : Interfaces.IWriter
    {
        TweetsReceiver receiver;
        TwitterConfig config;
        List<string> posts;


        public StatisticsWriter(TwitterConfig config, TweetsReceiver receiver)
        {
            this.config = config;
            this.receiver = receiver;
        }

        public List<string> Posts {
            get { return posts; }
        }

        public void WritePosts(){
            Dictionary<char,double> statistic = GetStatistic();

            WriteStatisticInConsole(statistic);

            posts = CreatePosts(statistic);

            // Можно также вывести твиты в консоль
            //foreach(var post in posts){
            //    Console.WriteLine(post);
            //}
        }

        Dictionary<char, double> GetStatistic(){
            Dictionary<char, double> statistic = new Dictionary<char, double>();

            string textWithLowerLetters = receiver.Data.ToLower();
            if(textWithLowerLetters.Equals("")){
                return statistic;
            }

            string onlyLetters = new string(textWithLowerLetters.Where(x => char.IsLetter(x)).ToArray());
            Dictionary<char,int> charCounts = onlyLetters.OrderByDescending(x => x).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int count = onlyLetters.Length;


            foreach(KeyValuePair<char,int> pair in charCounts){
                double proportion = Math.Round((double)pair.Value / count, 5);
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

        List<string> CreatePosts(Dictionary<char,double> statistic){
            List<string> finalPosts = new List<string>();

            Stack<string> jsonStatistic = GetJsonStatistic(statistic);

            string statisticMessage = "@" + receiver.Name + ", статистика для последних " + config.TweetsCount + " твитов:\n{";
            string postText = statisticMessage;

            while(jsonStatistic.Count != 0){
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
