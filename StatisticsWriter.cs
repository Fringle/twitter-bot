using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace TwitterBot
{
    public class StatisticsWriter : Interfaces.IWriter
    {
        private TweetsReceiver receiver;
        private TwitterConfig config;

        public StatisticsWriter(TwitterConfig config, TweetsReceiver receiver)
        {
            Console.WriteLine("Writer(config)");
            this.config = config;
            this.receiver = receiver;
        }

        public void WritePosts(){
            Console.WriteLine("Write()");
            Dictionary<char,double> statistic = GetStatistic();
            Console.WriteLine(String.Join("", statistic));
        }

        private Dictionary<char, double> GetStatistic(){
            Dictionary<char, double> statistic = new Dictionary<char, double>();

            string textWithLowerLetters = receiver.Data.ToLower();
            if(textWithLowerLetters.Equals("")){
                return statistic;
            }

            string onlyLetters = new string(textWithLowerLetters.Where(x => char.IsLetter(x)).ToArray());
            Dictionary<char,int> charCounts = onlyLetters.OrderBy(x => x).GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
            int count = onlyLetters.Length;


            foreach(KeyValuePair<char,int> pair in charCounts){
                double proportion = Math.Round((double)pair.Value / count, 5);
                statistic.Add(pair.Key, proportion);
            }

            return statistic;
        }
    }
}
