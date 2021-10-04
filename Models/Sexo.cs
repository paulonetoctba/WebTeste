using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebTeste.Models
{
    [Table("Sexo")]
    public class Sexo
    {
        [Key]
        public int SexoId { get; set; }

        [Display(Name = "Sexo")]
        public string Descricao { get; set; }
    }
}
