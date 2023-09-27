using Domain.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmpresaFornecedorServices : IEmpresaFornecedorServices
    {
        private readonly IEmpresaFornecedor _empresaFornecedor;

        public EmpresaFornecedorServices(IEmpresaFornecedor empresaFornecedor)
        {
            _empresaFornecedor = empresaFornecedor;
        }

        public async Task AdcionarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor)
        {
                await _empresaFornecedor.Adicionar(empresaFornecedor);
        }

        public async Task AtualizarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor)
        {
                await _empresaFornecedor.Atualizar(empresaFornecedor);
        }

    }
}
