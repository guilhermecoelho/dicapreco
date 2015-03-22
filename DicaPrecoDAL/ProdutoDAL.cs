using DicaPrecoEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicaPrecoDAL
{
    public class ProdutoDAL
    {
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        /// <summary>
        /// Converte os valores do dataReader do banco para o objeto produto
        /// </summary>
        /// <param name="rdr">DataReader</param>
        /// <returns>objeto Produto</returns>
        private Produto populaProduto(SqlDataReader rdr)
        {
            Produto retorno = new Produto();

            retorno.codProd = rdr["CodProd"].ToString() != "" ? Convert.ToInt32(rdr["CodProd"].ToString()) : 0;
            retorno.descrProd = rdr["DescrProd"].ToString() != "" ? rdr["DescrProd"].ToString() : " ";
            retorno.codUnidMed = rdr["CodUnidMed"].ToString() != "" ? Convert.ToInt32(rdr["CodUnidMed"].ToString()) : 0;
            retorno.descrUnidMed = rdr["DescrUnidMed"].ToString() != "" ? rdr["DescrUnidMed"].ToString() : " ";

            return retorno;
        }

        /// <summary>
        /// Lista produtos pela proc SpSeProduto
        /// </summary>
        /// <param name="produto">objeto produto</param>
        /// <returns>Lista de produtos</returns>
        public List<Produto> listaProdutos(Produto produto)
        {
            List<Produto> produtos = new List<Produto>();

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataReader rdr = null;

            if (String.IsNullOrEmpty(produto.descrProd))
            {
                produto.descrProd = "";
            }

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpSeProduto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DescrProd", produto.descrProd));

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    produtos.Add(populaProduto(rdr));
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                rdr.Close();
            }

            return produtos;
        }

        /// <summary>
        /// Lista produto pelo codigo pela proc SpSe1Produto
        /// </summary>
        /// <param name="codProd">código do produto</param>
        /// <returns>Objeto produto</returns>
        public Produto listaProdutosByCodigo(int codProd)
        {
            Produto produto = new Produto();

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataReader rdr = null;

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpSe1Produto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodProd", codProd));

                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    produto = populaProduto(rdr);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                rdr.Close();
            }

            return produto;
        }

        /// <summary>
        /// Salva um novo produto ou atualiza caso seu código já exista pela proc SpGrProduto
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        public bool SalvarProduto(Produto produto)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpGrProduto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodProd", produto.codProd));
                cmd.Parameters.Add(new SqlParameter("@DescrProd", produto.descrProd));
                cmd.Parameters.Add(new SqlParameter("@CodUnidMed", produto.codUnidMed));

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Exclui um produto pela proc SpExProduto
        /// </summary>
        /// <param name="codProd">Código do produto</param>
        public bool ExcluirProduto(int codProd)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpExProduto", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodProd", codProd));

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
