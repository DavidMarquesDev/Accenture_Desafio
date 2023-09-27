using Application.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class UserApplication : IUsersApplication
    {
        IUsers _IUsers;
        
        public UserApplication(IUsers IUsers)
        {
            _IUsers = IUsers;
        }
        public async Task<bool> AdcionarUsuario(string email, string senha, int idade, string celular)
        {
            return await _IUsers.AdcionarUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _IUsers.ExisteUsuario(email, senha);
        }
    }
}
