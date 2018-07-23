using ControleDeEstoque.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleDeEstoque.Web.Controllers
{
    public class CadastroController : Controller
    {

        private static List<GrupoDeProdutoModel> _listaGrupoProdutos = new List<GrupoDeProdutoModel>
        {
             new GrupoDeProdutoModel() { Id=1,Nome="Livro", Ativo=true },

             new GrupoDeProdutoModel() { Id=2,Nome="Mouses", Ativo=false },

             new GrupoDeProdutoModel() { Id = 3,Nome = "Smartphorne", Ativo = true },

             new GrupoDeProdutoModel() { Id = 4,Nome = "Monitores", Ativo = true }
    };

        [Authorize]
        public ActionResult GrupoDeProduto()
        {
            return View(GrupoDeProdutoModel.RecuperarLista());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult RecuperarGrupoProduto(int id)
        {
            return Json(GrupoDeProdutoModel.RecuperarPeloId(id));
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult ExcluirGrupoProduto(int id)
        {
            //var ret = false;
            //var registroBd = _listaGrupoProdutos.Find(p => p.Id == id);

            //if (registroBd != null)
            //{
            //    _listaGrupoProdutos.Remove(registroBd);
            //    ret = true;
            //}

            return Json(GrupoDeProdutoModel.ExcluirPeloId(id));
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult SalvarGrupoProduto(GrupoDeProdutoModel grupoProduto)
        {

            var resultado = "OK";
            var mensagens = new List<string>();
            var idSalvo = string.Empty;
            if (!ModelState.IsValid)
            {
                resultado = "AVISO";
                mensagens = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();
            }

            else
            {
                try
                {

                    var id = grupoProduto.SalvarGrupoProduto();

                    //var registroBd = _listaGrupoProdutos.Find(p => p.Id == grupoProduto.Id);

                    //if (registroBd == null)
                    //{
                    //    registroBd = grupoProduto;
                    //    registroBd.Id = _listaGrupoProdutos.Max(p => p.Id) + 1;
                    //    _listaGrupoProdutos.Add(registroBd);
                    //}
                    //else
                    //{
                    //    registroBd.Nome = grupoProduto.Nome;
                    //    registroBd.Ativo = grupoProduto.Ativo;
                    //}

                    if(id > 0)
                    {
                        idSalvo = id.ToString();
                    }
                    else
                    {
                        resultado = "ERRO";
                    }


                 
                }
                catch (Exception ex)
                {
                    resultado = "ERRO";
                }

               

            }
            //retornando em um objeto anonimo, criando nesse momento
            return Json(new {Resultado = resultado, Mensagens= mensagens, IdSalvo = idSalvo });
        }











        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult UnidadeMedida()
        {
            return View();
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult MarcasDeProduto()
        {
            return View();
        }
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult LocalProduto()
        {
            return View();
        }
        [Authorize]
        public ActionResult Produto()
        {
            return View();
        }
        [Authorize]
        public ActionResult Pais()
        {
            return View();
        }
        [Authorize]
        public ActionResult Estado()
        {
            return View();
        }
        [Authorize]
        public ActionResult Cidade()
        {
            return View();
        }
        [Authorize]
        public ActionResult Fornecedor()
        {
            return View();
        }
        [Authorize]
        public ActionResult PerfilUsuario()
        {
            return View();
        }
        [Authorize]
        public ActionResult Usuario()
        {
            return View();
        }
    }
}