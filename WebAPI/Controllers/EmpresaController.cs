using Application.Application;
using Application.Interfaces;
using Domain.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Entities.Notification;
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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaApplication _empresaApplication;
        private IFornecedorApplication _fornecedorApplication;

        public EmpresaController(IEmpresaApplication empresaApplication, IFornecedorApplication fornecedorApplication)

            
        {
            _empresaApplication = empresaApplication;
            _fornecedorApplication = fornecedorApplication;
        }


        [HttpPost("/api/AdcionarEmpresa")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarEmpresa(EmpresaModels empresa)
        {
            try
            {
                var newEmpresa = new Empresa
                {
                    CNPJ = empresa.CNPJ,
                    Nome = empresa.Nome,
                    CEP = empresa.CEP,
                    Ativo = empresa.Ativo,
                    DataCadastro = empresa.DataCadastro
                };

                await _empresaApplication.AdcionarEmpresa(newEmpresa);

                var novoEmpresaId = newEmpresa.EmpresaId;

                var fornecedores = newEmpresa.Fornecedores != null
                    ? newEmpresa.Fornecedores.Select(f => new { f.EmpresaID, f.FornecedorID }).ToList()
                    : null;

                var response = new
                {
                    newEmpresa.EmpresaId,
                    newEmpresa.CNPJ,
                    newEmpresa.Nome,
                    newEmpresa.CEP,
                    newEmpresa.DataCadastro,
                    Ativo = newEmpresa.Ativo ? "Ativo" : "Inativo", 
                    Fornecedores = fornecedores
                };

                // Retorna a resposta
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar a empresa: {ex.Message}");
            }
        }





        [HttpPut("/api/AtualizarEmpresa")]
        [Authorize]
        [Produces("application/json")]
        public async Task<List<NotificationEmpresa>> AtualizarEmpresa(EmpresaModels empresa)
        {
            // Verifica se a empresa e o Id não são nulos ou vazios
            if (empresa == null || empresa.EmpresaId == Guid.Empty)
            {
                return new List<NotificationEmpresa>
            {
                new NotificationEmpresa
                {
                    Mensagem = "Parâmetros inválidos"
                }
            };
            }

            var alterarEmpresa = await _empresaApplication.BuscarPorId(empresa.EmpresaId);

            if (alterarEmpresa != null)
            {
                alterarEmpresa.Nome = empresa.Nome;
                alterarEmpresa.CEP = empresa.CEP;
                alterarEmpresa.Ativo = empresa.Ativo;
                alterarEmpresa.DataAlteracao = empresa.DataAlteracao;

                await _empresaApplication.AtualizarEmpresa(alterarEmpresa);

                return alterarEmpresa.Notification;
            }
            else
            {
                return new List<NotificationEmpresa>
            {
                new NotificationEmpresa
                {
                    Mensagem = "Empresa não encontrada"
                }
            };
            }
        }

        [HttpGet("/api/ListarEmpresa")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var empresas = await _empresaApplication.Listar();

                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao listar empresas: {ex.Message}");
            }
        }

        [HttpGet("/api/ListarEmpresasAtivas")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> ListarEmpresasAtivas()
        {
            try
            {
                var empresasAtivas = await _empresaApplication.ListarEmpresasAtivas();

                return Ok(empresasAtivas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao listar empresas ativas: {ex.Message}");
            }
        }

        [HttpGet("/api/BuscarEmpresaPorId")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> BuscarPorIdAsync(Guid id)
        {
            try
            {
                // Busca a epresa por ID
                var empresa = await _empresaApplication.BuscarPorId(id);

                if (empresa == null)
                {
                    return NotFound("Empresa não encontrada");
                }

                return Ok(empresa);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar a empresa: {ex.Message}");
            }
        }

        [HttpDelete("/api/ExcluirEmpresa")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var empresa = await _empresaApplication.BuscarPorId(id);

                if (empresa == null)
                {
                    return NotFound("Empresa não encontrada");
                }

                await _empresaApplication.Excluir(empresa);

                return Ok("Empresa excluída com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir a empresa: {ex.Message}");
            }
        }
    }
}
