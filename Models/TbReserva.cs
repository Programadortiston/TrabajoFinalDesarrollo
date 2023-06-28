using System;
using System.Collections.Generic;

namespace WebAppProyectoFinal.Models;

public partial class TbReserva
{
    public int IdPrestamo { get; set; }

    public string FecPrestamo { get; set; } = null!;

    public string FecDevolucion { get; set; } = null!;

    public int IdCli { get; set; }

    public string Estado { get; set; } = null!;

    public virtual TbCliente IdCliNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleReserva> TbDetalleReservas { get; set; } = new List<TbDetalleReserva>();

    LibreriasC conexion = new LibreriasC();
    public string getNomCli()
    {
        string nombre = (from tCli in conexion.TbClientes
                         where tCli.IdCli == IdCli
                         select tCli.NomCli + " " + tCli.ApeCli).Single();
        return nombre;
    }
}
