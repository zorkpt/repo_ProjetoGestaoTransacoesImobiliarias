using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoTransacoesImobiliarias.Models
{
    public class Contact
    {
        public string? ClientID { get; set; }

        public TipoContacto Tipo { get; set; }

        public string? Descricao { get; set; }

        public enum TipoContacto
        {
            Email,
            Telm,
            Telefone
        }
        public Contact(string? clientId, TipoContacto tipo, string descricao)
        {
            ClientID = clientId;
            Tipo = tipo;
            Descricao = descricao;
        }

    }
}
