using CadastroProdutos.Models;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace CadastroProdutos.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Produto()
        {
            return View();
        }


        [HttpPost]
        public bool Cadastrar(Produto produto)
        {
            //var strConn = ConfigurationManager.ConnectionStrings["ProdutosDB"].ConnectionString;

            string connStr = "server=localhost;user=root;database=produtostore;port =3306;password=147852";
            MySqlConnection sqlConn = new MySqlConnection(connStr);
            try
            {

                    sqlConn.Open();


                    string sql = "INSERT INTO `produtostore`.`tblproduto` (`Nome`,`Descricao`,`Ativo`,`Perecivel`,`CategoriaID`)" +
                    "VALUES ( '" + produto.Nome + "', '" +  produto.Descricao + "', " + Convert.ToByte(produto.Ativo) + ", " + Convert.ToByte(produto.Perecivel) + ", " +
                     " " + produto.CategoriaId + " );";

                    MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                    cmd.ExecuteNonQuery();


                    sqlConn.Close();
                
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }


        [HttpPost]
        public JsonResult ConsultaProduto()
        {
            List<Produto> listProdutos = new List<Produto>();
            List<ProdutoCategoria> listProdutoCategoria = new List<ProdutoCategoria>();


            string connStr = "server=localhost;user=root;database=produtostore;port =3306;password=147852";
            MySqlConnection sqlConn = new MySqlConnection(connStr);
            try
            {


                sqlConn.Open();

                string sql = "SELECT `tblproduto`.`Id`, `tblproduto`.`Nome`, `tblproduto`.`Descricao`,`tblproduto`.`Ativo`,`tblproduto`.`Perecivel`," +
                    "`tblproduto`.`CategoriaId`, `tblcategoriaproduto`.`Nome`, `tblcategoriaproduto`.`Descricao`, `tblcategoriaproduto`.`Ativo`" +
                    "FROM `produtostore`.`tblproduto` INNER JOIN " +
                    "`produtostore`.`tblcategoriaproduto` on tblcategoriaproduto.Id = tblproduto.CategoriaID ORDER BY `tblproduto`.`Id`; ";

                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Produto produto = new Produto();

                    produto.Id = Convert.ToInt32(rdr["Id"]);
                    produto.Nome = rdr["Nome"].ToString();
                    produto.Descricao = rdr["Descricao"].ToString();
                    produto.Ativo = Convert.ToByte(rdr["Ativo"]);
                    produto.Perecivel = Convert.ToByte(rdr["Perecivel"]);
                    produto.CategoriaId = Convert.ToInt32(rdr["CategoriaId"]);

                    listProdutos.Add(produto);
                }

                rdr.Close();
                cmd.ExecuteNonQuery();
                sqlConn.Close();

            }
            catch (Exception e)
            {
                return Json(e);
            }
            var listJson = JsonConvert.SerializeObject(listProdutos);
            var resultado = new { obj = listJson};
            
        return Json(resultado);
 
        }

        public bool Atualizar(Produto produto)
        {
            //var strConn = ConfigurationManager.ConnectionStrings["ProdutosDB"].ConnectionString;

            string connStr = "server=localhost;user=root;database=produtostore;port=3306;password=147852";
            MySqlConnection sqlConn = new MySqlConnection(connStr);
            try
            {

                sqlConn.Open();


                string sql = "UPDATE `produtostore`.`tblproduto`" +
                "SET `Nome` = '" +produto.Nome + "',`Descricao` = '" + produto.Descricao + "',`Ativo` = " + produto.Ativo + "," +
                "`Perecivel` = " + produto.Perecivel + ",`CategoriaID` = " + produto.CategoriaId + "" +
                " WHERE `Id` = " + produto.Id + "; ";

                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                cmd.ExecuteNonQuery();


                sqlConn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Deletar(string id)
        {
            //var strConn = ConfigurationManager.ConnectionStrings["ProdutosDB"].ConnectionString;

            string connStr = "server=localhost;user=root;database=produtostore;port =3306;password=147852";
            MySqlConnection sqlConn = new MySqlConnection(connStr);
            try
            {

                sqlConn.Open();


                string sql = "DELETE FROM `produtostore`.`tblproduto` WHERE Id = "+ id + "; ";

                MySqlCommand cmd = new MySqlCommand(sql, sqlConn);
                cmd.ExecuteNonQuery();


                sqlConn.Close();

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}