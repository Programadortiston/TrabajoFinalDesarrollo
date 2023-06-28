using System;
using System.Collections.Generic;

namespace WebAppProyectoFinal.Models;

public partial class TbLibro
{
    public int IdLibro { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public string Genero { get; set; } = null!;

    public int Año { get; set; }

    public int Stock { get; set; }

    public string? Link { get; set; }

    public virtual ICollection<TbDetalleReserva> TbDetalleReservas { get; set; } = new List<TbDetalleReserva>();
}
