using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmpresaServices : IEmpresaServices
    {
        private readonly IEmpresa _empresaServices;

        public EmpresaServices(IEmpresa empresaServices)
        {
            _empresaServices = empresaServices;
        }

        public async Task AdcionarEmpresa(Empresa empresa)
        {
            var validarCnpj = empresa.ValidarPropriedadeStringObrigatoria(empresa.CNPJ, "CNPJ");
            var validarNome = empresa.ValidarPropriedadeStringObrigatoria(empresa.Nome, "Nome_Fantasia");

            // Ajuste aqui: Usei && em vez de || para verificar se ambos são verdadeiros
            if (validarCnpj && validarNome)
            {
                empresa.DataCadastro = DateTime.Now;
                empresa.Ativo = true; // Ajuste aqui, pois o valor de Ativo parece não depender da validação
                await _empresaServices.Adicionar(empresa);
            }
        }

        public async Task AtualizarEmpresa(Empresa empresa)
        {
            var validarCnpj = empresa.ValidarPropriedadeStringObrigatoria(empresa.CNPJ, "CNPJ");
            var validarNome = empresa.ValidarPropriedadeStringObrigatoria(empresa.Nome, "Nome_Fantasia");

            // Ajuste aqui: Usei && em vez de || para verificar se ambos são verdadeiros
            if (validarCnpj && validarNome)
            {
                empresa.DataAlteracao = DateTime.Now;
                empresa.Ativo = empresa.Ativo; 
                await _empresaServices.Atualizar(empresa);
            }
        }

        public async Task<List<Empresa>> ListarEmpresasAtivas()
        {
            return await _empresaServices.ListarEmpresas(e => e.Ativo);
        }
    }
}
