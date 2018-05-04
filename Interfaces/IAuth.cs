using System;
namespace TwitterBot.Interfaces
{
    /*
     * Интерфейс для авторизации в соц. сети
     */
    public interface IAuth
    {
        void Auth(IAuthConfig config);
    }
}
