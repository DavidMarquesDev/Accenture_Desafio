using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface ICepServices
    {
        Task AdcionarCep(Cep cep);
        Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id);
    }
}
