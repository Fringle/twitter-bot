using System;
namespace TwitterBot.Interfaces
{
    public interface IDataHandler
    {
        string NeededData();

        string[] HandleData(string data);
    }
}
