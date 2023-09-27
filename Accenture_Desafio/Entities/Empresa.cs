using Entities.Enums;
using Entities.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_EMPRESA")]
    public class Empresa : NotificationEmpresa
    {
        [Key] // Esta anotação indica que a propriedade é uma chave primária
        [Column("EmpresaId")] // Nome da coluna no banco de dados
        public Guid EmpresaId { get; set; } // Tipo e nome da propriedade

        [Column("CNPJ")]
        public string CNPJ { get; set; }

        [Column("NOME_FANTASIA")]
        public string Nome { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("DataAlteracao")]
        public DateTime DataAlteracao { get; set; }


        [Column("Ativo")]
        public bool Ativo { get; set; }

        public List<EmpresaFornecedor>? Fornecedores { get; set; }

    }
}
