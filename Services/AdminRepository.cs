using WebAppProyectoFinal.Models;

namespace WebAppProyectoFinal.Services
{
    public class AdminRepository : IAdmin
    {
        private LibreriasC conexion = new LibreriasC();
        public bool ValidateLogin(TbAdmin obj)
        {
            var objAdmin = (from tAdmin in conexion.TbAdmins
                            where tAdmin.UserAdmin == obj.UserAdmin
                            && tAdmin.ContraAdmin == obj.ContraAdmin
                            select tAdmin).FirstOrDefault();
            if(objAdmin == null)
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
