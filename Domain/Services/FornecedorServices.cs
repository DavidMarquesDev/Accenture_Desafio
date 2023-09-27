using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class FornecedorServices: IFornecedorServices
    {
        private readonly IFornecedor _fornecedorServices; 

        public FornecedorServices(IFornecedor fornecedorServices)
        {
            _fornecedorServices = fornecedorServices;
        }

        public async Task AdcionarFornecedor(Fornecedor fornecedor)
        {
            var validarCpfCnpj = fornecedor.ValidarPropriedadeString(fornecedor.CPFCNPJ,"CNPJ");
            var validarNome = fornecedor.ValidarPropriedadeString(fornecedor.Nome, "Nome_Fantasia");

            if (validarCpfCnpj || validarNome)
            {
                fornecedor.DataCadastro = DateTime.Now;
                fornecedor.Ativo = true;
                await _fornecedorServices.Adicionar(fornecedor);
            }
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            var validarCpfCnpj = fornecedor.ValidarPropriedadeString(fornecedor.CPFCNPJ, "CNPJ");
            var validarNome = fornecedor.ValidarPropriedadeString(fornecedor.Nome, "Nome_Fantasia");

            if (validarCpfCnpj || validarNome)
            {
                fornecedor.DataCadastro = DateTime.Now;
                fornecedor.Ativo = true;
                await _fornecedorServices.Atualizar(fornecedor);
            }
        }

        public async Task<List<Fornecedor>> ListarFornecedoresAtivos()
        {
            return await _fornecedorServices.ListarFornecedor(e => e.Ativo);
        }
    }
}
