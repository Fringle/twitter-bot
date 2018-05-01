using System;
namespace TwitterBot
{
    public class Twitter : Interfaces.ISocial
    {
        private Interfaces.IWriter tweetsWriter;

        public void Auth(){
            Console.WriteLine("Auth()");
        }

        public void SetWriter(Interfaces.IWriter writer){
            //this.tweetsWriter = writer;
            Console.WriteLine("SetWriter()");
        }

        public void GetData(string data){
            Console.WriteLine("GetData({0})", data);
        }

        public void HandleData(){
            Console.WriteLine("HandleData()");
        }

        public void PushPosts(){
            Console.WriteLine("PushPosts()");
        }
    }
}
