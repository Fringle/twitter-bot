using System;

namespace TwitterBot
{
    class TwitterBot
    {
        public static void Main(string[] args)
        {

            Interfaces.ISocialFactory social = new TwitterFactory();

            Interfaces.IAuthConfig config = social.CreateConfig();
            Interfaces.IAuth authenticator = social.CreateAuthenticator();

            authenticator.Auth(config);

            Interfaces.IDataHandler handler = social.CreateDataHandler();
            Interfaces.IReceiver receiver = social.CreateReceiver();
            Interfaces.IWriter writer = social.CreateWriter();
            Interfaces.IPublisher publisher = social.CreatePublisher();

            Console.WriteLine(handler.NeededData());
            string inputData = Console.ReadLine();

            while(!inputData.Equals("")){

                string[] handledData = handler.HandleData(inputData);
                receiver.Receive(handledData);
                writer.WritePosts();
                publisher.PublishPosts();

                Console.WriteLine(handler.NeededData());
                inputData = Console.ReadLine();

            }
        }
    }
}
