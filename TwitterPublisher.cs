using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TwitterPublisher : Interfaces.IPublisher
    {
        private StatisticsWriter statisticWriter;

        public TwitterPublisher(StatisticsWriter writer){
            statisticWriter = writer;
        }

        public void PublishPosts(){
            statisticWriter.Posts.Reverse();
            foreach(string post in statisticWriter.Posts){
                Tweet.PublishTweet(post);
            }
        }
    }
}
