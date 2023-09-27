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
    public class EmpresaRepository : GenericsRepository<Empresa>, IEmpresa
    {
        private readonly DbContextOptions<Context> _OptionBuilder;
        public EmpresaRepository()
        {
            _OptionBuilder = new DbContextOptions<Context>();
        }
        public async Task<List<Empresa>> ListarEmpresas(Expression<Func<Empresa, bool>> exEmpresa)
        {
            using (var data = new Context(_OptionBuilder))
            {
                return await data.Empresa.Where(exEmpresa).AsNoTracking().ToListAsync();
            }
        }
    }
}
