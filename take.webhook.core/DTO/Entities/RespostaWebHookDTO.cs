using System;
using System.Collections.Generic;
using System.Text;

namespace take.webhook.core.DTO.Entities
{
    public class RespostaWebHookDTO
    {
        public int IdRespostaWebHook { get; set; }

        //Message
        public string Type { get; set; }
        public object Content { get; set; }
        public string Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public object Metadata { get; set; }


        // Tracking
        public string OwnerIdentity { get; set; }
        public object Contact { get; set; }
        public string MessageId { get; set; }
        public DateTime? StorageDate { get; set; }
        public string Category { get; set; }
        public string Action { get; set; }
        public object Extras { get; set; }

    }
}
