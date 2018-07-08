using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Web.Models
{
    public class LoginViewModel
    {



        [Required(ErrorMessage ="Informe o campo Usuário")]
        [Display(Name = "Usuário")]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "Informe o campo Senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required]
        [Display(Name = "Lembra-Me")]
        public bool LembrarMe { get; set; }
    }
}