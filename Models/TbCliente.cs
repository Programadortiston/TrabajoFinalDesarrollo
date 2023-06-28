using System;
using System.Collections.Generic;

namespace WebAppProyectoFinal.Models;

public partial class TbCliente
{
    public int IdCli { get; set; }

    public string NomCli { get; set; } = null!;

    public string ApeCli { get; set; } = null!;

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
