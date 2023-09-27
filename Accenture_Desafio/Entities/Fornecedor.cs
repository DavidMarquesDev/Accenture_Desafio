using Entities.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_FORNECEDOR")]
    public class Fornecedor : NotificationFornecedor
    {
        [Key] // Esta anotação indica que a propriedade é uma chave primária
        [Column("FornecedorId")] // Nome da coluna no banco de dados
        public Guid FornecedorId { get; set; } // Tipo e nome da propriedade

        [Column("CPFCNPJ")]
        public string CPFCNPJ { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }
        
        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }

        [Column("DataNascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("RG")]
        public string RG { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }

        public List<EmpresaFornecedor>? Empresas { get; set; }

    }
}
