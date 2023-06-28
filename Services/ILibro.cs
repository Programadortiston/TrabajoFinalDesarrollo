using WebAppProyectoFinal.Models;
namespace WebAppProyectoFinal.Services
{
    public interface ILibro
    {
        public IEnumerable<TbLibro> GetAllBooks();
        TbLibro GetLibro(int id);
        void add(TbLibro obj);
        void remove(int id);
        TbLibro edit(int id);
        void editDetails(TbLibro obj);
    }
}
