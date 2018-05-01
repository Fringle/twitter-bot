using System;
namespace TwitterBot.Interfaces
{
    public interface ISocialFactory
    {
        IConfig CreateConfig();

        ISocial CreateSocial(IConfig config);

        IWriter CreateWriter(IConfig config);
    }
}
