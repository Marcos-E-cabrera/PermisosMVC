using System;
using System.Collections.Generic;

namespace ProyectoRol.Models.DB;

public partial class Modulo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Operacione> Operaciones { get; set; } = new List<Operacione>();
}
