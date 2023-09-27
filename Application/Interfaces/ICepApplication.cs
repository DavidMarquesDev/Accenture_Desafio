using Application.Interfaces.Generics;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICepApplication : IGenericsApplication<Cep>
    {
        Task AdcionarCep(Cep cep);

        Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id);
    }
}
