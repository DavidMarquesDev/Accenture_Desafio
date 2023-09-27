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
    public class EmpresaFornecedorRepository : GenericsRepository<EmpresaFornecedor>, IEmpresaFornecedor
    {
        private readonly DbContextOptions<Context> _OptionBuilder;
        public EmpresaFornecedorRepository()
        {
            _OptionBuilder = new DbContextOptions<Context>();
        }
        public async Task<List<EmpresaFornecedor>> ListarEmpresaFornecedor(Expression<Func<EmpresaFornecedor, bool>> exEmpresaFornecedor)
        {
            using (var data = new Context(_OptionBuilder))
            {
                return await data.EmpresaFornecedor.Where(exEmpresaFornecedor).AsNoTracking().ToListAsync();
            }
        }

        //public async Task<bool> VincularEmpresaFornecedor(Guid empresaId, Guid fornecedorId)
        //{

        //    try
        //    {
        //        using (var data = new Context(_optionsbuilder))
        //        {
        //            await data.EmpresaFornecedor.AddAsync(
        //                  new EmpresaFornecedor
        //                  {
        //                      Empresa = empresaId,
        //                      Fornecedor = fornecedorId,
        //                  });

        //            await data.SaveChangesAsync();

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }


        //    return true;

        //}
    }
}
