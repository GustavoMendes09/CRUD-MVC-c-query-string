using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Perecivel { get; set; }
        public int CategoriaId { get; set; }

    }
}