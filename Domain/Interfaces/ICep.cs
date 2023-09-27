using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICep : IGenerics<Cep>
    {
        Task<List<Cep>> ListarCep(Expression<Func<Cep, bool>> exCep);

        Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id);


    }
}
