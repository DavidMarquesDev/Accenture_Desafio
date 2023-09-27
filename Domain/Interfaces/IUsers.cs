using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUsers
    {
        Task<bool> AdcionarUsuario(string email, String senha, int idade, string celular);
        Task<bool> ExisteUsuario(string email, String senha);
    }
}
