using System;
using Tweetinvi;
namespace TwitterBot
{
    /*
     * Публикует переданные сообщения в Twitter'е от авторизованного пользователя
     */
    public class TwitterPublisher : Interfaces.IPublisher
    {
        StatisticsWriter statisticWriter;

        public TwitterPublisher(StatisticsWriter writer){
            statisticWriter = writer;
        }

        public void PublishPosts(){
            // Можно также вывести твиты в консоль

            //foreach(var post in posts){
            //    Console.WriteLine(post);
            //}

            // Разворачиваем твиты для чтения сверху вниз, в алфовитном порядке
            statisticWriter.Posts.Reverse();
            foreach(string post in statisticWriter.Posts){
                Tweet.PublishTweet(post);
            }

            // Достаточно сложно обработать ошибки из Twitter'a
            //var latestException = ExceptionHandler.GetLastException();
        }
    }
}
