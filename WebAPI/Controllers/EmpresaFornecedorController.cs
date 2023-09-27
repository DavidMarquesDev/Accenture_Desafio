using Application.Application;
using Application.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers.Models;
using WebAPI.Models;
using WebAPI.Token;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmpresaFornecedorController : ControllerBase
    {
        private readonly IEmpresaFornecedorApplication _empresaFornecedorApplication;

        public EmpresaFornecedorController(IEmpresaFornecedorApplication empresaFornecedorApplication)
        {
            _empresaFornecedorApplication = empresaFornecedorApplication;
        }

        [HttpPost("/api/AdicionarEmpresaFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarEmpresaFornecedor(EmpresaFornecedorModels EmpresaFornecedor)
        {
            try
            {
                var newEmpresaFornecedor = new EmpresaFornecedor
                {
                    EmpresaFornecedorId = Guid.NewGuid(),
                    EmpresaID = EmpresaFornecedor.EmpresaId,
                    FornecedorID = EmpresaFornecedor.FornecedorId,
                };

                await _empresaFornecedorApplication.AdcionarEmpresaFornecedor(newEmpresaFornecedor);

                var response = new
                {
                    newEmpresaFornecedor.EmpresaFornecedorId,
                    newEmpresaFornecedor.EmpresaID,
                    newEmpresaFornecedor.FornecedorID,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar a Empresa/Fornecedor: {ex.Message}");
            }
        }



        [HttpPut("/api/AtualizarEmpresaFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task AtualizarEmpresaFornecedor(EmpresaFornecedorModels EmpresaFornecedor)
        {
            var alterarEmpresaFornecedor = await _empresaFornecedorApplication.BuscarPorId(EmpresaFornecedor.EmpresaFornecedorId);

            if (alterarEmpresaFornecedor != null)
            {
                alterarEmpresaFornecedor.EmpresaID = EmpresaFornecedor.EmpresaId;
                alterarEmpresaFornecedor.FornecedorID = EmpresaFornecedor.FornecedorId;

                await _empresaFornecedorApplication.AtualizarEmpresaFornecedor(alterarEmpresaFornecedor);
            }
            else
            {
                // Adicionar notificações ou outras lógicas de erro, se necessário
            }
        }


        [HttpGet("/api/ListarEmpresaFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var EmpresaFornecedores = await _empresaFornecedorApplication.Listar();

                return Ok(EmpresaFornecedores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao listar Empresas/Fornecedors: {ex.Message}");
            }
        }



        [HttpGet("/api/BuscarEmpesaFornecedorPorId")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> BuscarPorIdAsync(Guid id)
        {
            try
            {
                var EmpresaFornecedor = await _empresaFornecedorApplication.BuscarPorId(id);

                if (EmpresaFornecedor == null)
                {
                    return NotFound("Fornecedor não encontrada");
                }

                return Ok(EmpresaFornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar a Empresa/Fornecedor: {ex.Message}");
            }
        }

        [HttpDelete("/api/ExcluirEmpresaFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var EmpresaFornecedor = await _empresaFornecedorApplication.BuscarPorId(id);

                if (EmpresaFornecedor == null)
                {
                    return NotFound("Fornecedor não encontrada");
                }

                await _empresaFornecedorApplication.Excluir(EmpresaFornecedor);

                return Ok("Fornecedor excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir a Empresa/Fornecedor: {ex.Message}");
            }
        }
    }
}
