using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public interface ILogin
    {
        bool ValidateLogin(TbLogin obj);
    }
}
