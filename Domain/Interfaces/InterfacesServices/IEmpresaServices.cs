using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IEmpresaServices
    {
        Task AdcionarEmpresa(Empresa empresa);
        Task AtualizarEmpresa(Empresa empresa);
        Task<List<Empresa>> ListarEmpresasAtivas();
    }
}
