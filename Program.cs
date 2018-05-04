using System;

namespace TwitterBot
{
    class TwitterBot
    {
        /*
         * Логика программы написана достаточно абстрактно, я думаю, её можно применить и к различным соц. сетям.
         * Создаем объект для авторизации, объект конфига, авторизуемся, далее создаем объекты обработчика консольных команд,
         * получателя данных из соцсети, писателя записей и публикатора записей, и ,наконец, выполняем необходимые команды.
         * Обработка ошибок в блоке while, чтобы увидеть ошибку и дальше вводить команды.
         * 
         * В основе лежит абстрактная фабрика, которая создает все необходимые объекты.
         * Описания абстрактных объектов в их интерфейсах, а для конкретных объектов в их реализациях
         */

        public static void Main(string[] args)
        {
            Interfaces.ISocialFactory social = new TwitterFactory();

            Interfaces.IAuthConfig config = social.CreateConfig();
            Interfaces.IAuth authenticator = social.CreateAuthenticator();

            authenticator.Auth(config);

            Interfaces.IDataHandler handler = social.CreateDataHandler();
            Interfaces.IReceiver receiver = social.CreateReceiver();
            Interfaces.IWriter writer = social.CreateWriter();
            Interfaces.IPublisher publisher = social.CreatePublisher();

            Console.WriteLine(handler.Info());
            string inputData = Console.ReadLine();

            while(!inputData.Equals("")){

                try
                {
                    string[] handledData = handler.HandleData(inputData);
                    receiver.Receive(handledData);
                    writer.WritePosts();
                    publisher.PublishPosts();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine(handler.Info());
                inputData = Console.ReadLine();

            }
        }
    }
}
