using Domain.Interfaces;
using Entities.Entities;
using Infrastructure.Config;
using Infrastructure.Repository.Generics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class FornecedorRepository : GenericsRepository<Fornecedor>, IFornecedor
    {
        private readonly DbContextOptions<Context> _OptionBuilder;
        public FornecedorRepository()
        {
            _OptionBuilder = new DbContextOptions<Context>();
        }
        public async Task<List<Fornecedor>> ListarFornecedor(Expression<Func<Fornecedor, bool>> exFornecedor)
        {
            using (var data = new Context(_OptionBuilder))
            {
                return await data.Fornecedor.Where(exFornecedor).AsNoTracking().ToListAsync();
            }
        }
    }
}
