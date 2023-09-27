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
    public class FornecedorApplication : IFornecedorApplication
    {
        IFornecedor _IFornecedor;
        IFornecedorServices _IFornecedorServices;

        public FornecedorApplication(IFornecedor Ifornecedor, IFornecedorServices IfornecedorServices)
        {
            _IFornecedor = Ifornecedor;
            _IFornecedorServices = IfornecedorServices;
        }
        public async Task AdcionarFornecedor(Fornecedor fornecedor)
        {
            await _IFornecedorServices.AdcionarFornecedor(fornecedor);
        }

        public async Task AtualizarFornecedor(Fornecedor fornecedor)
        {
            await _IFornecedorServices.AtualizarFornecedor(fornecedor);
        }

        public async Task<List<Fornecedor>> ListarFornecedoresAtivos()
        {
            return await _IFornecedorServices.ListarFornecedoresAtivos();
        }

        public async Task Adicionar(Fornecedor Objeto)
        {
            await _IFornecedor.Adicionar(Objeto);
        }

        public async Task Atualizar(Fornecedor Objeto)
        {
            await _IFornecedor.Atualizar(Objeto);
        }

        public async Task<Fornecedor> BuscarPorId(Guid Id)
        {
            return await _IFornecedor.BuscarPorId(Id);
        }

        public async Task Excluir(Fornecedor Objeto)
        {
            await _IFornecedor.Excluir(Objeto);
        }

        public async Task<List<Fornecedor>> Listar()
        {
            return await _IFornecedor.Listar();
        }
    }
}
