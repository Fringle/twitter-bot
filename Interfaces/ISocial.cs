using System;
namespace TwitterBot.Interfaces
{
    public interface ISocial
    {
        void Auth();

        void SetWriter(IWriter writer);

        void GetData(string data);

        void HandleData();

        void PushPosts();
    }
}
