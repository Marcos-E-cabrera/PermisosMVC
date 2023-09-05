using ProyectoRol.Models.DB;
using System.Collections;

namespace ProyectoRol.Models.Services
{
    public interface IAcceso
    {
        //public Task<IEnumerable<DB.Usuario>> Listar();

        public Models.DB.Usuario ValidarUsuario(string user, string password);

    }
}
