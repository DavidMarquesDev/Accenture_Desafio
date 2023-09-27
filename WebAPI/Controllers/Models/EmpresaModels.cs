using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers.Models
{
    public class EmpresaModels
    {
        public Guid EmpresaId { get; set; }
        public string CNPJ { get; set; }
        public string Nome { get; set; }
        public string CEP { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public bool Ativo { get; set; }

        // Adicione a propriedade de fornecedores
        //public List<EmpresaFornecedor>? Fornecedores { get; set; }
    }
}
