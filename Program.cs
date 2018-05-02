using System;

namespace TwitterBot
{
    class TwitterBot
    {
        public static void Main(string[] args)
        {
            Config config = new Config();
            var twitter = new Twitter(config);

            twitter.Auth();

            var writer = new Writer(config);
            twitter.SetWriter(writer);

            Console.WriteLine("Пожалуйста введите логин twitter-пользователя");
            string inputData = Console.ReadLine();
            while(!inputData.Equals("")){

                twitter.GetData(inputData);
                twitter.HandleData();
                twitter.PushPosts();

                Console.WriteLine("Пожалуйста введите логин twitter-пользователя");
                inputData = Console.ReadLine();

            }
        }
    }
}
