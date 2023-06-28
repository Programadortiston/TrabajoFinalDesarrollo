using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public class LoginRepository : ILogin
    {
        private LibreriasC conexion = new LibreriasC();
        public bool ValidateLogin(TbLogin obj)
        {
            var objLogin = (from tLogin in conexion.TbLogins
                            where tLogin.Usuario == obj.Usuario
                            && tLogin.Contra == obj.Contra
                            select tLogin).FirstOrDefault();
            if(objLogin == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
