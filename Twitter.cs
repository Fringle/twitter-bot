using System;
using Tweetinvi;
namespace TwitterBot
{
    public class Twitter : Interfaces.ISocial
    {
        private Interfaces.IAuthConfig config;
        private Interfaces.IWriter tweetsWriter;

        public Twitter(Interfaces.IAuthConfig config){
            Console.WriteLine("Twitter(config)");
            this.config = config;
        }

        public void Auth(){
            Tweetinvi.Auth.SetUserCredentials(this.config.ConsumerKey,
                                              this.config.ConsumerSecret,
                                              this.config.AccessToken,
                                              this.config.AccessTokenSecret);
            Console.WriteLine("Auth()");
        }

        public void SetWriter(Interfaces.IWriter writer){
            this.tweetsWriter = writer;
            Console.WriteLine("SetWriter()");
        }

        public void GetData(string data){
            string userName = GetName(data);
            var user = User.GetUserFromScreenName(data);
            Console.WriteLine("GetData({0})", data);
        }

        public void HandleData(){
            Console.WriteLine("HandleData()");
        }

        public void PushPosts(){
            Console.WriteLine("PushPosts()");
        }

        private string GetName(string data){
            if(data.StartsWith("@")){
                return data.Substring(1);
            }
            return data;
        }
    }
}
