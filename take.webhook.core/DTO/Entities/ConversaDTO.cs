using System;
using System.Collections.Generic;
using System.Text;

namespace take.webhook.core.DTO.Entities
{
    public class ConversaDTO
    {
        public int IdConversa { get; set; }
        public DateTime? DataEnvio { get; set; }
        public string Categoria { get; set; }
        public string Acao { get; set; }
        public string NomeUsuario { get; set; }
        public string Extras { get; set; }
        public DateTime? DataMensagem { get; set; }
        public string Origem { get; set; }
        public string Texto { get; set; }
    }
}
