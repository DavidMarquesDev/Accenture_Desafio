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
    public class EmpresaFornecedorApplication : IEmpresaFornecedorApplication
    {
        IEmpresaFornecedor _IempresaFornecedor;
        IEmpresaFornecedorServices _empresaFornecedorServices;
        public EmpresaFornecedorApplication(IEmpresaFornecedor IempresaFornecedor, IEmpresaFornecedorServices empresaFornecedorServices)
        {
            _IempresaFornecedor = IempresaFornecedor;
            _empresaFornecedorServices = empresaFornecedorServices;
        }
       
        public async Task AdcionarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor)
        {
            await _empresaFornecedorServices.AdcionarEmpresaFornecedor(empresaFornecedor);
        }

        public async Task AtualizarEmpresaFornecedor(EmpresaFornecedor empresaFornecedor)
        {
            await _empresaFornecedorServices.AtualizarEmpresaFornecedor(empresaFornecedor);
        }

        public async Task Adicionar(EmpresaFornecedor Objeto)
        {
            await _IempresaFornecedor.Adicionar(Objeto);
        }

        public async Task Atualizar(EmpresaFornecedor Objeto)
        {
            await _IempresaFornecedor.Atualizar(Objeto);
        }

        public async Task<EmpresaFornecedor> BuscarPorId(Guid Id)
        {
            return await _IempresaFornecedor.BuscarPorId(Id);
        }

        public async Task Excluir(EmpresaFornecedor Objeto)
        {
            await _IempresaFornecedor.Excluir(Objeto);
        }

        public async Task<List<EmpresaFornecedor>> Listar()
        {
            return await _IempresaFornecedor.Listar();
        }
    }
}
