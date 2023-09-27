using Application.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFornecedorApplication : IGenericsApplication<Fornecedor>
    {
        Task AdcionarFornecedor(Fornecedor fornecedor);
        Task AtualizarFornecedor(Fornecedor fornecedor);
        Task<List<Fornecedor>> ListarFornecedoresAtivos();
    }
}
