using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;

namespace WebTeste.Models
{
    [Table("Usuario")]
    public class User
    {
        [Key]
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }
       
        public int SexoId { get; set; }

        public Sexo SexoDesc { get; set; }
        //public List<Sexo> Sexo { get; set; }
    }
}