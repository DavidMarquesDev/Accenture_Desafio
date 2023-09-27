using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Infrastructure.Config;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericsRepository<ApplicationUser>, IUsers
    {

        private readonly DbContextOptions<Context> _optionsbuilder;

        public UserRepository()
        {
            _optionsbuilder = new DbContextOptions<Context>();
        }

        public async Task<bool> AdcionarUsuario(string email, string senha, int idade, string celular)
        {

            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    await data.ApplicationUser.AddAsync(
                          new ApplicationUser
                          {
                              Email = email,
                              PasswordHash = senha,
                              Idade = idade,
                              Celular = celular,
                              Tipo = TipoUsuario.Comum
                          });

                    await data.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;

        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {

            try
            {
                using (var data = new Context(_optionsbuilder))
                {
                    return await data.ApplicationUser.
                        Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                        .AsNoTracking()
                        .AnyAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
