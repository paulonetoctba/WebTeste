using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Collections.Generic;
using System.Globalization;

namespace WebTeste.Models
{
    public class UserViewModel
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O Nome do Usuário é obrigatório", AllowEmptyStrings = false), Display(Name = "Nome do Usuário"), StringLength(200, MinimumLength = 3)]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento"), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}"), Required(ErrorMessage = "A Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string DataNascimento { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informar o Sexo é obrigatório", AllowEmptyStrings = false)]
        public Int32 SexoId { get; set; }

        [Display(Name = "Sexo")]
        public Sexo SexoDesc { get; set; }

        public List<Sexo> ListaSexo { get; set; }
    }
}
