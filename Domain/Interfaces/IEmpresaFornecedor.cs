using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmpresaFornecedor : IGenerics<EmpresaFornecedor>
    {
        Task<List<EmpresaFornecedor>> ListarEmpresaFornecedor(Expression<Func<EmpresaFornecedor, bool>> exEmpresaFornecedor);
    }
}
