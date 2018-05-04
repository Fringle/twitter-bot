using System;
namespace TwitterBot.Interfaces
{
    /*
     * Интерфейс для получения данных из соц. сети
     */
    public interface IReceiver
    {
        void Receive(string[] data);
    }
}
