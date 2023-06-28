using WebAppProyectoFinal.Models;
namespace WebAppProyectoFinal.Services
{
    public class LibroRepository : ILibro
    {
        private LibreriasC conexion = new LibreriasC();

        public void add(TbLibro obj)
        {
            conexion.TbLibros.Add(obj);
            conexion.SaveChanges();
        }

        public TbLibro edit(int id)
        {
            var ObjEncontrado = (from tbLib in conexion.TbLibros
                                 where tbLib.IdLibro == id
                                 select tbLib).Single();
            return ObjEncontrado;
        }

        public void editDetails(TbLibro obj)
        {
            var objEncontrado = (from tbLib in conexion.TbLibros
                                 where tbLib.IdLibro == obj.IdLibro
                                 select tbLib).FirstOrDefault();
            objEncontrado.Titulo = obj.Titulo;
            objEncontrado.Genero = obj.Genero;
            objEncontrado.Autor = obj.Autor;
            objEncontrado.Año = obj.Año;
            objEncontrado.Stock = obj.Stock;
            objEncontrado.Link = obj.Link;
            conexion.SaveChanges();
        }

        public IEnumerable<TbLibro> GetAllBooks()
        {
            return conexion.TbLibros;
        }

        public TbLibro GetLibro(int id)
        {
            var ObjProducto = (from tlib in conexion.TbLibros
                               where tlib.IdLibro == id
                               select tlib).Single();
            return ObjProducto;
        }

        public void remove(int id)
        {
            var objEncontrado = (from tLib in conexion.TbLibros
                                 where tLib.IdLibro == id
                                 select tLib).Single();
            conexion.Remove(objEncontrado);
            conexion.SaveChanges();
        }
    }
}
