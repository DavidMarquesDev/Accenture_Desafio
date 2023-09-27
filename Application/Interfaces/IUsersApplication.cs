using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUsersApplication
    {
        Task<bool> AdcionarUsuario(string email, String senha, int idade, string celular);

        Task<bool> ExisteUsuario(string email, String senha);
    }
}
