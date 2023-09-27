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
    public class CepController : ControllerBase
    {
        private readonly ICepApplication _cepApplication;

        public CepController(ICepApplication cepApplication, IFornecedorApplication fornecedorApplication)


        {
            _cepApplication = cepApplication;
        }


        [HttpPost("/api/AdicionarCep")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> AdicionarCep(CepModels cep)
        {
            try
            {
                var newCep = new Cep
                {
                    Rua = cep.Rua,
                    Cidade = cep.Cidade,
                    Bairro = cep.Bairro,
                    Estado = cep.Estado
                };

                if (cep.EmpresaId != null)
                {
                    newCep.EmpresaId = cep.EmpresaId;
                }

                if (cep.FornecedorId != null)
                {
                    newCep.FornecedorId = cep.FornecedorId;
                }

                await _cepApplication.AdcionarCep(newCep);

                var response = new
                {
                    newCep.CepId,
                    newCep.EmpresaId,
                    newCep.FornecedorId,
                    newCep.Rua,
                    newCep.Cidade,
                    newCep.Bairro,
                    newCep.Estado,
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao adicionar o Cep: {ex.Message}");
            }
        }

        [HttpGet("/api/BuscarCep/{id}")]
        [Authorize]
        [Produces("application/json")]
        public async Task<IActionResult> BuscarCepPorEmpresaIdOrFornecedorId(Guid id)
        {
            try
            {
                var cep = await _cepApplication.BuscarCepPorEmpresaIdOrFornecedorId(id);

                if (cep == null)
                {
                    return NotFound("Cep não encontrado");

                }
                var primeiroCep = cep.First();
                var newCep = new Cep
                {
                    Rua = primeiroCep.Rua,
                    Bairro = primeiroCep.Bairro,
                    Cidade = primeiroCep.Cidade,
                    Estado =primeiroCep.Estado,
                };

                var response = new
                {
                    rua = newCep.Rua,
                    bairro = newCep.Bairro,
                    cidade = newCep.Cidade,
                    estado = newCep.Estado
                };

                return Ok(cep);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao buscar o Cep: {ex.Message}");
            }
        }



    }
}
