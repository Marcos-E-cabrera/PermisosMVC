using System;
using System.Collections.Generic;

namespace ProyectoRol.Models.DB;

public partial class RolOperacion
{
    public int Id { get; set; }

    public int IdRol { get; set; }

    public int IdOperacion { get; set; }

    public virtual Operacione IdOperacionNavigation { get; set; } = null!;

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
