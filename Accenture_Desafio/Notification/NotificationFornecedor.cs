using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Notification
{
    public class NotificationFornecedor
    {
        public NotificationFornecedor()
        {
            Notification = new List<NotificationFornecedor>();
        }

        [NotMapped]
        public string CPFCNPJ { get; set; }

        [NotMapped]
        public string Nome { get; set; }

        [NotMapped]
        public string Email { get; set; }

        [NotMapped]
        public string CEP { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<NotificationFornecedor> Notification;

        public bool ValidarPropriedadeString(string value, string cPFCNPJ)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(cPFCNPJ))
            {
                Notification.Add(new NotificationFornecedor
                {
                    Mensagem = "Campo Obrigatório",
                    CPFCNPJ = cPFCNPJ
                });

                return false;
            }
            return true;
        }
    }
}
