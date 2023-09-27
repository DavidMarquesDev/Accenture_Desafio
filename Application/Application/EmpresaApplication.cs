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
    public class EmpresaApplication : IEmpresaApplication
    {
        IEmpresa _IEmpresa;
        IEmpresaServices _IEmpresaServices;

        public EmpresaApplication(IEmpresa Iempresa, IEmpresaServices IempresaServices)
        {
            _IEmpresa = Iempresa;
            _IEmpresaServices = IempresaServices;
        }
        public async Task AdcionarEmpresa(Empresa empresa)
        {
            await _IEmpresaServices.AdcionarEmpresa(empresa);
        }

        public async Task AtualizarEmpresa(Empresa empresa)
        {
            await _IEmpresaServices.AtualizarEmpresa(empresa);
        }

        public async Task<List<Empresa>> ListarEmpresasAtivas()
        {
            return await _IEmpresaServices.ListarEmpresasAtivas();
        }

        public async Task Adicionar(Empresa Objeto)
        {
            await _IEmpresa.Adicionar(Objeto);
        }

        public async Task Atualizar(Empresa Objeto)
        {
            await _IEmpresa.Atualizar(Objeto);
        }

        public async Task<Empresa> BuscarPorId(Guid Id)
        {
            return await _IEmpresa.BuscarPorId(Id);
        }

        public async Task Excluir(Empresa Objeto)
        {
            await _IEmpresa.Excluir(Objeto);
        }

        public async Task<List<Empresa>> Listar()
        {
            return await _IEmpresa.Listar();
        }
    }
}
