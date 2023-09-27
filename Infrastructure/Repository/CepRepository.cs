using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Config;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CepRepository : GenericsRepository<Cep>, ICep
    {
        private readonly DbContextOptions<Context> _OptionBuilder;
        public CepRepository()
        {
            _OptionBuilder = new DbContextOptions<Context>();
        }
        public async Task<List<Cep>> ListarCep(Expression<Func<Cep, bool>> exCep)
        {
            using (var data = new Context(_OptionBuilder))
            {
                return await data.Cep.Where(exCep).AsNoTracking().ToListAsync();
            }
        }
        public async Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id)
        {
            using (var data = new Context(_OptionBuilder))
            {
                var ceps = await data.Cep
                    .Where(c => c.EmpresaId == id || c.FornecedorId == id)
                    .ToListAsync();

                return ceps;
            }
        }
    }
}
