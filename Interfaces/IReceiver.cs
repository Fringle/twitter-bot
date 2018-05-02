using System;
namespace TwitterBot.Interfaces
{
    public interface IReceiver
    {
        void Receive(string[] data);
    }
}
