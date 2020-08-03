using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CategoriaController : Controller
    {
        private ProdutosRepositorio _repositorio;

        // GET: Categoria
        public PartialViewResult Menu(string categoria = null)
        {
            ViewBag.CategoriaSelecionada = categoria;
            _repositorio = new ProdutosRepositorio();

            IEnumerable<String> categorias = _repositorio.Produtos
                .Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c);


            return PartialView(categorias);
        }
    }
}