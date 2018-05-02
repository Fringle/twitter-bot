using System;
namespace TwitterBot.Interfaces
{
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
