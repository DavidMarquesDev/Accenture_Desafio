using Entities.Notification;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_EMPRESA_FORNECEDOR")]
    public class EmpresaFornecedor
    {

        [Key] // Esta anotação indica que a propriedade é uma chave primária
        [Column("EmpresaFornecedorId")] // Nome da coluna no banco de dados
        public Guid EmpresaFornecedorId { get; set; } // Tipo e nome da propriedade

        [ForeignKey("Empresa")]
        public Guid? EmpresaID { get; set; }
        public virtual Empresa? Empresa { get; set; }

        [ForeignKey("Fornecedor")]
        public Guid? FornecedorID { get; set; }
        public virtual Fornecedor? Fornecedor { get; set; }
    }
}

