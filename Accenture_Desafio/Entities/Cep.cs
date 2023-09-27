using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entities
{
    [Table("TB_CEP")]
    public class Cep
    {
        [Key]
        [Column("CepId")]
        public Guid CepId { get; set; }

        [Column("EmpresaId")]
        public Guid? EmpresaId { get; set; }

        [Column("FornecedorId")]
        public Guid? FornecedorId { get; set; }

        [Column("Rua")]
        public string Rua { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Estado")]
        public string Estado { get; set; }

    }
}
