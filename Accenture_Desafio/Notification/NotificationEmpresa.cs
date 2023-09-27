using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notification
{
    public class NotificationEmpresa
    {
        public NotificationEmpresa()
        {
            Notification = new List<NotificationEmpresa>();
        }

        [NotMapped]
        public string CNPJ { get; set; }

        [NotMapped]
        public string Nome { get; set; }

        [NotMapped]
        public string CEP { get; set; }

        [NotMapped]
        public DateTime DataCadastro { get; set; }

        [NotMapped]
        public DateTime DataAlteracao { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<NotificationEmpresa> Notification { get; set; }

        public bool ValidarPropriedadeString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Notification.Add(new NotificationEmpresa
                {
                    Mensagem = $"{propertyName} é um campo obrigatório."
                });

                return false;
            }
            return true;
        }

        public bool ValidarPropriedadeStringObrigatoria(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                Notification.Add(new NotificationEmpresa
                {
                    Mensagem = $"{propertyName} é um campo obrigatório.",
                    CNPJ = CNPJ, // Mantenha as referências a CNPJ, Nome e CEP
                    Nome = Nome,
                    CEP = CEP
                });

                return false;
            }
            return true;
        }
    }
}
