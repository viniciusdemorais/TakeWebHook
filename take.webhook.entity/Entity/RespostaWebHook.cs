using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace take.webhook.entity.Entity
{
    public class RespostaWebHook
    {
        public DateTime DataCriacao { get; set; }

        [Key]
        public int IdRespostaWebHook { get; set; }

        //Message
        public string Type { get; set; }
        public string Content { get; set; }
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Metadata { get; set; }


        // Tracking
        public string OwnerIdentity { get; set; }
        public string Contact { get; set; }
        public string MessageId { get; set; }
        public DateTime? StorageDate { get; set; }
        public string Category { get; set; }
        public string Action { get; set; }
        public string Extras { get; set; }
    }
}
