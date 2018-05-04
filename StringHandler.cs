using System;
namespace TwitterBot
{ 
    /*
     * Конкретный обработчик данных, получает строку - на выходе массив с именем
     */
    public class StringHandler : Interfaces.IDataHandler
    {
        public string Info(){
            return "Введите логин Twitter пользователя:";
        }

        public string[] HandleData(string data){
            string[] output = new string[1];

            // Убираем лишние пробелы в начале
            string name = data.TrimStart();

            // Берем только первое слово, Twitter не позволяет и использовать пробелы в логинах
            int index = name.IndexOf(' ');
            name = index <= 0 ? name : name.Substring(0, index);

            // Считываем логин, независимо, начинается ли он с @
            name = name.StartsWith("@") ? name.Substring(1) : name;

            Console.WriteLine("Используется для имени \"{0}\"", name);

            output[0] = name;

            return output;
        }
    }
}
