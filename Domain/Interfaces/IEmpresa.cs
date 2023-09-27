using Domain.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IEmpresa : IGenerics<Empresa>
    {
        Task<List<Empresa>> ListarEmpresas(Expression<Func<Empresa, bool>> exEmpresa);

    }
}
