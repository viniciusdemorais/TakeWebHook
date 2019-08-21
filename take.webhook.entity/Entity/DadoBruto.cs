using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace take.webhook.entity.Entity
{
    public class DadoBruto
    {
        [Key]
        public int IdDadoBruto { get; set; }
        public string Dado { get; set; }
    }
}
