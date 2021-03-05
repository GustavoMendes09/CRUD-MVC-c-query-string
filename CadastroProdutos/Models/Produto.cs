using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public byte Ativo { get; set; }
        public byte Perecivel { get; set; }
        public int CategoriaId { get; set; }
        public ProdutoCategoria DescricaoCategoria { get; set; }

    }
}