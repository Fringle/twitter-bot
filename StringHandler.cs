using System;
namespace TwitterBot
{
    public class StringHandler : Interfaces.IDataHandler
    {
        private TwitterConfig config;

        public StringHandler(TwitterConfig config)
        {
            this.config = config;
        }

        public string NeededData(){
            return this.config.InputData;
        }

        public string[] HandleData(string data){
            Console.WriteLine("HandleData({0})", data);
            string[] output = new string[1];

            output[0] = data.StartsWith("@") ? data.Substring(1) : data;

            return output;
        }
    }
}
