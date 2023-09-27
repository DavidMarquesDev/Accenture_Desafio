using Application.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class CepApplication : ICepApplication
    {
        ICep _ICep;
        ICepServices _ICepServices;

        public CepApplication(ICep Icep, ICepServices IcepServices)
        {
            _ICep = Icep;
            _ICepServices = IcepServices;
        }
        public async Task AdcionarCep(Cep cep)
        {
            await _ICepServices.AdcionarCep(cep);
        }

        public async Task<List<Cep>> BuscarCepPorEmpresaIdOrFornecedorId(Guid id)
        {
            return await _ICep.BuscarCepPorEmpresaIdOrFornecedorId(id);
        }

        public async Task Adicionar(Cep Objeto)
        {
            await _ICep.Adicionar(Objeto);
        }

        public async Task Atualizar(Cep Objeto)
        {
            await _ICep.Atualizar(Objeto);
        }

        public async Task<Cep> BuscarPorId(Guid Id)
        {
            return await _ICep.BuscarPorId(Id);
        }

        public async Task Excluir(Cep Objeto)
        {
            await _ICep.Excluir(Objeto);
        }

        public async Task<List<Cep>> Listar()
        {
            return await _ICep.Listar();
        }
    }
}
