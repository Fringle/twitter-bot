namespace TwitterBot
{
    public class TwitterFactory : Interfaces.ISocialFactory
    {
        TwitterConfig config;
        TweetsReceiver receiver;
        StatisticsWriter writer;

        public Interfaces.IAuthConfig CreateConfig(){
            config = new TwitterConfig();
            return config;
        }

        public Interfaces.IAuth CreateAuthenticator(){
            return new TwitterAuthenticator();
        }

        public Interfaces.IDataHandler CreateDataHandler(){
            return new StringHandler();
        }

        public Interfaces.IReceiver CreateReceiver(){
            receiver = new TweetsReceiver(config);
            return receiver;
        }

        public Interfaces.IWriter CreateWriter(){
            writer = new StatisticsWriter(config, receiver);
            return writer;
        }

        public Interfaces.IPublisher CreatePublisher(){
            return new TwitterPublisher(writer);
        }
    }
}
