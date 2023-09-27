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
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplication _fornecedorApplication;

        public FornecedorController(IFornecedorApplication FornecedorApplication)
        {
            _fornecedorApplication = FornecedorApplication;
        }

        [HttpPost("/api/AdcionarFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarFornecedor(FornecedorModels Fornecedor)
        {
            try
            {
                var newFornecedor = new Fornecedor
                {
                    CPFCNPJ = Fornecedor.CPFCNPJ,
                    Nome = Fornecedor.Nome,
                    CEP = Fornecedor.CEP,
                    Email = Fornecedor.Email,
                    Ativo = Fornecedor.Ativo,
                    DataCadastro = Fornecedor.DataCadastro
                }; 
                
                if (string.IsNullOrEmpty(Fornecedor.RG))
                {
                    newFornecedor.RG = ""; 
                }
                else
                {
                    newFornecedor.RG = Fornecedor.RG;
                }

                if (Fornecedor.DataNascimento.HasValue)
                {
                    newFornecedor.DataNascimento = (DateTime)Fornecedor.DataNascimento;
                }

                // Adiciona a nova Fornecedor
                await _fornecedorApplication.AdcionarFornecedor(newFornecedor);

                var empresas = newFornecedor.Empresas != null
                    ? newFornecedor.Empresas.Select(f => new { f.FornecedorID, f.EmpresaID }).ToList()
                    : null;

                var response = new
                {
                    newFornecedor.FornecedorId,
                    newFornecedor.CPFCNPJ,
                    newFornecedor.Nome,
                    newFornecedor.CEP,
                    newFornecedor.Email,
                    newFornecedor.DataCadastro,
                    Ativo = newFornecedor.Ativo ? "Ativo" : "Inativo", 
                    Empresa = empresas
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar a Fornecedor: {ex.Message}");
            }
        }


        [HttpPut("/api/AtualizarFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<List<NotificationFornecedor>> AtualizarFornecedor(FornecedorModels Fornecedor)
        {
            if (Fornecedor == null || Fornecedor.FornecedorId == Guid.Empty)
            {
                return new List<NotificationFornecedor>
            {
                new NotificationFornecedor
                {
                    Mensagem = "Parâmetros inválidos"
                }
            };
            }

            var alterarFornecedor = await _fornecedorApplication.BuscarPorId(Fornecedor.FornecedorId);

            if (alterarFornecedor != null)
            {
                alterarFornecedor.Nome = Fornecedor.Nome;
                alterarFornecedor.CEP = Fornecedor.CEP;
                alterarFornecedor.Ativo = Fornecedor.Ativo;
                alterarFornecedor.Email = Fornecedor.Email;
                alterarFornecedor.DataAlteracao = Fornecedor.DataAlteracao;

                await _fornecedorApplication.AtualizarFornecedor(alterarFornecedor);

                return alterarFornecedor.Notification;
            }
            else
            {
                return new List<NotificationFornecedor>
            {
                new NotificationFornecedor
                {
                    Mensagem = "Fornecedor não encontrada"
                }
            };
            }
        }

        [HttpGet("/api/ListarFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Listar()
        {
            try
            {
                var Fornecedors = await _fornecedorApplication.Listar();

                return Ok(Fornecedors);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao listar Fornecedors: {ex.Message}");
            }
        }

        [HttpGet("/api/ListarFornecedoresAtivos")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> ListarFornecedoresAtivos()
        {
            try
            {
                var FornecedorsAtivas = await _fornecedorApplication.ListarFornecedoresAtivos();

                return Ok(FornecedorsAtivas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao listar Fornecedors ativas: {ex.Message}");
            }
        }

        [HttpGet("/api/BuscarFornecedorPorId")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> BuscarPorIdAsync(Guid id)
        {
            try
            {
                var Fornecedor = await _fornecedorApplication.BuscarPorId(id);

                if (Fornecedor == null)
                {
                    return NotFound("Fornecedor não encontrada");
                }

                return Ok(Fornecedor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar a Fornecedor: {ex.Message}");
            }
        }

        [HttpDelete("/api/ExcluirFornecedor")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> Excluir(Guid id)
        {
            try
            {
                var Fornecedor = await _fornecedorApplication.BuscarPorId(id);

                if (Fornecedor == null)
                {
                    return NotFound("Fornecedor não encontrada");
                }

                await _fornecedorApplication.Excluir(Fornecedor);

                return Ok("Fornecedor excluído com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao excluir a Fornecedor: {ex.Message}");
            }
        }
    }
}
