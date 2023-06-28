using System;
using System.Collections.Generic;

namespace WebAppProyectoFinal.Models;

public partial class TbLogin
{
    public string Usuario { get; set; } = null!;

    public string Contra { get; set; } = null!;

    LibreriasC conexion = new LibreriasC();
    public int getIdCliente()
    {
        string[] nombreCompleto = Usuario.Split(new char[] { '.' });
        string nombre = nombreCompleto[0];
        string apellido = nombreCompleto[1];
        int idCli = (from tbCli in conexion.TbClientes
                     where tbCli.NomCli.Equals(nombre)
                     && tbCli.ApeCli.Equals(apellido)
                     select tbCli.IdCli).FirstOrDefault();
        return idCli;
    }
    public string getNomCli()
    {
        string nombre = (from tCli in conexion.TbClientes
                         where tCli.IdCli == getIdCliente()
                         select tCli.NomCli + " " + tCli.ApeCli).Single();
        return nombre;

    }
}
