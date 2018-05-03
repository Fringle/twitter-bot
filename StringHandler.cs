using System;
namespace TwitterBot
{
    public class StringHandler : Interfaces.IDataHandler
    {
        public string Info(){
            return "Введите логин Twitter пользователя:";
        }

        public string[] HandleData(string data){
            string[] output = new string[1];

            string name = data.TrimStart();

            int index = name.IndexOf(' ');
            name = index <= 0 ? name : name.Substring(0, index);

            name = name.StartsWith("@") ? name.Substring(1) : name;

            Console.WriteLine("Используется для имени \"{0}\"", name);

            output[0] = name;

            return output;
        }
    }
}
