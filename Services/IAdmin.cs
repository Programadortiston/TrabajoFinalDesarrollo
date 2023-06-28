using WebAppProyectoFinal.Models;
namespace WebAppProyectoFinal.Services
{
    public interface IAdmin
    {
        bool ValidateLogin(TbAdmin obj);
    }
}
