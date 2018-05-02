using System;
namespace TwitterBot
{
    public class TwitterFactory : Interfaces.ISocialFactory
    {
        private TwitterConfig config;

        public Interfaces.IAuthConfig CreateConfig(){
            Console.WriteLine("CreateConfig()");
            this.config = new TwitterConfig();
            return this.config;
        }

        public Interfaces.IAuth CreateAuthenticator(){
            Console.WriteLine("CreateAuthenticator()");
            return new TwitterAuthenticator();
        }

        public Interfaces.IDataHandler CreateDataHandler(){
            Console.WriteLine("CreateDataHandler()");
            return new StringHandler(this.config);
        }

        public Interfaces.IReceiver CreateReceiver(){
            Console.WriteLine("CreateReceiver()");
            return new TweetsReceiver(this.config);
        }

        public Interfaces.IWriter CreateWriter(){
            Console.WriteLine("CreateWriter()");
            return new StatisticsWriter(this.config);
        }

        public Interfaces.IPublisher CreatePublisher(){
            Console.WriteLine("CreatePublisher()");
            return new TwitterPublisher();
        }
    }
}
