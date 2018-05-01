using System;

namespace TwitterBot
{
    class TwitterBot
    {
        public static void Main(string[] args)
        {
            Interfaces.ISocialFactory factory = new TwitterFactory();
            Interfaces.IConfig config = factory.CreateConfig();
            Interfaces.ISocial social = factory.CreateSocial(config);

            social.Auth();

            Interfaces.IWriter writer = factory.CreateWriter(config);

            social.SetWriter(writer);

            string inputData = Console.ReadLine();
            while(inputData != "/break"){

                social.GetData(inputData);
                social.HandleData();
                social.PushPosts();
                inputData = Console.ReadLine();

            }
        }
    }
}
