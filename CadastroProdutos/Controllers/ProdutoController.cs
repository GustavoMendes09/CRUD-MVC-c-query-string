using CadastroProdutos.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroProdutos.Controllers
{
    public class ProdutoController : Controller
    {

        public ActionResult Produto()
        {
            return View();
        }
        [HttpPost]
        public bool Cadastrar(Produto produto)
        {
            var strConn = ConfigurationManager.ConnectionStrings["ProdutosDB"].ConnectionString;
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(strConn))
                {
                    sqlConn.Open();

                    SqlCommand sCom = sqlConn.CreateCommand();
                    sCom.Connection = sqlConn;

                    sCom.CommandText = "INSERT INTO tblProduto (Nome , Descricao , Categoria, Perecivel , CategoriaId)" +
                    "VALUES ( '" + produto.Nome + "', '" + produto.Descricao + "', '" + produto.Categoria + "', '" + produto.Perecivel + "', " +
                     " '" + produto.CategoriaId + "' );";

                    var linhasAfetadas = sCom.ExecuteNonQuery();

                    sqlConn.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}