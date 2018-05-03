using System;
using System.Linq;
using System.Collections.Generic;
namespace TwitterBot
{
    public class StatisticsWriter : Interfaces.IWriter
    {
        private TweetsReceiver receiver;
        private TwitterConfig config;
        private List<string> posts;


        public StatisticsWriter(TwitterConfig config, TweetsReceiver receiver)
        {
            Console.WriteLine("Writer(config)");
            this.config = config;
            this.receiver = receiver;
        }

        public List<string> Posts {
            get { return this.posts; }
        }

        public void WritePosts(){
            Console.WriteLine("Write()");
            Dictionary<char,double> statistic = GetStatistic();

            WriteStatisticInConsole(statistic);

            this.posts = CreatePosts(statistic);


            foreach(var post in this.posts){
                Console.WriteLine(post);
            }
        }

        private Dictionary<char, double> GetStatistic(){
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

        private void WriteStatisticInConsole(Dictionary<char,double> statistic){
            string statisticMessage = "@" + receiver.Name + ", статистика для последних 5 твитов:\n{";
            Console.WriteLine(statisticMessage);
            foreach(KeyValuePair<char,double> pair in statistic){
                Console.WriteLine("'{0}' : {1}", pair.Key, pair.Value.ToString().Replace(",", "."));
            }
            Console.WriteLine("}");
        }

        private List<string> CreatePosts(Dictionary<char,double> statistic){
            List<string> finalPosts = new List<string>();

            Stack<string> jsonStatistic = GetJsonStatistic(statistic);

            string statisticMessage = "@" + receiver.Name + ", статистика для последних 5 твитов:\n{";
            string postText = statisticMessage;

            while(jsonStatistic.Count != 0){
                if (postText.Length + jsonStatistic.Peek().Length + 1 <= this.config.TweetLength)
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

        private Stack<string> GetJsonStatistic(Dictionary<char,double> statistic){
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
