using Entities.Entities;
using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Controllers.Models
{
    public class CepModels
    {
        public Guid CepId { get; set; }

        public Guid? EmpresaId { get; set; }

        public Guid? FornecedorId { get; set; }

        public string Rua { get; set; }

        public string Cidade { get; set; }

        public string Bairro { get; set; }

        public string Estado { get; set; }

    }
}
