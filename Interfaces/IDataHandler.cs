using System;
namespace TwitterBot.Interfaces
{
    /*
     * Интерфейс для обработки входных данных, есть возможность реализовать его для принятия 
     * больших команд с различными аргументами и флагами
     */
    public interface IDataHandler
    {
        string Info(); // Выводим, что хотим получить, либо возможные команды нашего приложения

        string[] HandleData(string data);
    }
}
