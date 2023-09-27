using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFornecedor : IGenerics<Fornecedor>
    {
        Task<List<Fornecedor>> ListarFornecedor(Expression<Func<Fornecedor, bool>> exFornecedor);
    }
}
