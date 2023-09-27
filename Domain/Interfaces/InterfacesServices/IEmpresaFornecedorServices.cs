using Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IEmpresaFornecedorServices
    {
        Task AdcionarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor);
        Task AtualizarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor);
    }
}
