using Application.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmpresaApplication : IGenericsApplication<Empresa>
    {
        Task AdcionarEmpresa(Empresa empresa);
        Task AtualizarEmpresa(Empresa empresa);
        Task<List<Empresa>> ListarEmpresasAtivas();
    }
}
