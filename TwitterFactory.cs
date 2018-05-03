using System;
namespace TwitterBot
{
    public class TwitterFactory : Interfaces.ISocialFactory
    {
        private TwitterConfig config;
        private TweetsReceiver receiver;
        private StatisticsWriter writer;

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
            this.receiver = new TweetsReceiver(this.config);
            return this.receiver;
        }

        public Interfaces.IWriter CreateWriter(){
            Console.WriteLine("CreateWriter()");
            this.writer = new StatisticsWriter(this.config, this.receiver);
            return this.writer;
        }

        public Interfaces.IPublisher CreatePublisher(){
            Console.WriteLine("CreatePublisher()");
            return new TwitterPublisher(this.writer);
        }
    }
}
