using System;
using System.Collections.Generic;

namespace ProyectoRol.Models.DB;

public partial class Operacione
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int IdModulo { get; set; }

    public virtual Modulo IdModuloNavigation { get; set; } = null!;

    public virtual ICollection<RolOperacion> RolOperacions { get; set; } = new List<RolOperacion>();
}
