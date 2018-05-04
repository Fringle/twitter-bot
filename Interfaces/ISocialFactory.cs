using System;
namespace TwitterBot.Interfaces
{
    /*
     * Абстрактная фабрика для создания зависимых объектов.
     * Зависимость между объектами можно прописать различными способами:
     * статическими методами или хранением ссылок, можно использовать и базу данных для хранения информации 
     */
    public interface ISocialFactory
    {
        IAuthConfig CreateConfig();

        IAuth CreateAuthenticator();

        IDataHandler CreateDataHandler();

        IReceiver CreateReceiver();

        IWriter CreateWriter();

        IPublisher CreatePublisher();
    }
}
