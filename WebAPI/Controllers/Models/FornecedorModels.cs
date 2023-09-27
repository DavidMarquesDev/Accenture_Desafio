using Entities.Entities;
using System;

namespace WebAPI.Controllers.Models
{
    public class FornecedorModels
    {
        public Guid FornecedorId { get; set; }
        public string CPFCNPJ { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? RG { get; set; }
        public bool Ativo { get; set; }

       // public List<EmpresaFornecedor>? Empresas { get; set; }
    }
}
