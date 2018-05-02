using System;
using Tweetinvi;
namespace TwitterBot
{
    public class TwitterPublisher : Interfaces.IPublisher
    {
        public void PublishPosts(){
            Console.WriteLine("PublishPosts()");
            Tweet.PublishTweet("Hello World!\nHi!");
        }
    }
}
