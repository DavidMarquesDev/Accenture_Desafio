using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class CepServices : ICepServices
    {
        private readonly ICep _cepServices;

        public CepServices(ICep cepServices)
        {
            _cepServices = cepServices;
        }

        public async Task AdcionarCep(Cep cep)
        {
            await _cepServices.Adicionar(cep);
        }


        public async Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id)
        {
            return await _cepServices.BuscarCepPorEmpresaIdOrFornecedorId(id);
        }
    }
}
