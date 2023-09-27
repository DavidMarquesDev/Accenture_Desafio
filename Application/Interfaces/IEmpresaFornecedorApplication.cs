using Application.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmpresaFornecedorApplication : IGenericsApplication<EmpresaFornecedor>
    {
        Task AdcionarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor);
        Task AtualizarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor);
    }

}
