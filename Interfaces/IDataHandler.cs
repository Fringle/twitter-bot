using System;
namespace TwitterBot.Interfaces
{
    public interface IDataHandler
    {
        string Info();

        string[] HandleData(string data);
    }
}
