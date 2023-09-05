using Microsoft.EntityFrameworkCore;
using ProyectoRol.Models.DB;

namespace ProyectoRol.Models.Services
{
    public class Acceso : IAcceso
    {
        private readonly MiSistema02Context _context;

        public Acceso(MiSistema02Context context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<DB.Usuario>> Listar() => await _context.Usuarios
        //        .Include(u => u.IdRolNavigation.Nombre) 
        //        .ToListAsync();

        public Usuario ValidarUsuario(string user, string password)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Email == user.Trim() && x.Password == password.Trim());

        }
    }
}
