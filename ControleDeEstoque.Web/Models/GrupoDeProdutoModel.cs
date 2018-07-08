using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleDeEstoque.Web.Models
{
    public class GrupoDeProdutoModel
    {



        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatorio")]
        public string  Nome { get; set; }


        public bool Ativo { get; set; }
    }
}