using System;
namespace TwitterBot
{
    public class TwitterFactory : Interfaces.ISocialFactory
    {
        public Interfaces.IConfig CreateConfig(){
            Console.WriteLine("CreateConfig()");
            return new Config();
        }

        public Interfaces.ISocial CreateSocial(Interfaces.IConfig config){
            Console.WriteLine("CreateSocial()");
            return new Twitter();
        }

        public Interfaces.IWriter CreateWriter(Interfaces.IConfig config){
            Console.WriteLine("CreateWriter()");
            return new Writer();
        }
    }
}