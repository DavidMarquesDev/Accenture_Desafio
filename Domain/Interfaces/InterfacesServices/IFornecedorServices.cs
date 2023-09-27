using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IFornecedorServices
    {
        Task AdcionarFornecedor(Fornecedor fornecedor);
        Task AtualizarFornecedor(Fornecedor fornecedor);
        Task<List<Fornecedor>> ListarFornecedoresAtivos();
    }
}
