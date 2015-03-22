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
    public class UnidadeMedidaDAL
    {
        public string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }
        /// <summary>
        /// Converte os valores do dataReader do banco para o objeto unidadeMedida
        /// </summary>
        /// <param name="rdr">DataReader</param>
        /// <returns>objeto unidadeMedida</returns>
        private UnidadeMedida populaUnidadeMedida(SqlDataReader rdr)
        {
            UnidadeMedida retorno = new UnidadeMedida();

            retorno.codUnidMed = rdr["CodUnidMed"].ToString() != "" ? Convert.ToInt32(rdr["CodUnidMed"].ToString()) : 0;
            retorno.descrUnidMed = rdr["DescrUnidMed"].ToString() != "" ? rdr["DescrUnidMed"].ToString() : " ";

            return retorno;
        }

        /// <summary>
        /// Lista unidades de medida pela proc SpSeUnidMed
        /// </summary>
        /// <param name="unidadeMedida">objeto unidadeMedida</param>
        /// <returns>Lista objeto unidadeMedida</returns>
        public List<UnidadeMedida> listaUnidadesMedida(UnidadeMedida unidadeMedida)
        {
            List<UnidadeMedida> unidadeMedidas = new List<UnidadeMedida>();

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataReader rdr = null;

            if(String.IsNullOrEmpty(unidadeMedida.descrUnidMed)){
                unidadeMedida.descrUnidMed = " ";
            }
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpSeUnidMed", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@DescrUnidMed", unidadeMedida.descrUnidMed));

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    unidadeMedidas.Add(populaUnidadeMedida(rdr));
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

            return unidadeMedidas;
        }

        /// <summary>
        /// Lista unidadeMedida pelo código pela proc SpSe1UnidMed
        /// </summary>
        /// <param name="codUnidMed">código unidadeMedida</param>
        /// <returns>Objeto unidadeMedida</returns>
        public UnidadeMedida listaUnidadeMedidaByCodigo(int codUnidMed)
        {
            UnidadeMedida unidadeMedida = new UnidadeMedida();

            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataReader rdr = null;

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpSe1UnidMed", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodUnidMed", codUnidMed));

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    unidadeMedida = populaUnidadeMedida(rdr);
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

            return unidadeMedida;
        }

        /// <summary>
        /// Salva uma unidade de medida ou atualiza caso seu código já exista pela proc SpGrUnidMed
        /// </summary>
        /// <param name="unidadeMedida">Objeto unidadeMedida</param>
        public bool SalvarUnidadeMedida(UnidadeMedida unidadeMedida)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpGrUnidMed", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodUnidMed", unidadeMedida.codUnidMed));
                cmd.Parameters.Add(new SqlParameter("@DescrUnidMed", unidadeMedida.descrUnidMed));

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
        /// Exclui uma unidade de medida pela proc SpExUnidMed
        /// </summary>
        /// <param name="codUnidMed">código da unidade de medida</param>
        public bool ExcluirUnidadeMedida(int codUnidMed)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());

            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SpExUnidMed", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@CodUnidMed", codUnidMed));

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
        /// Verifica se a unidade Medidada está vinculada a algum produto
        /// </summary>
        /// <param name="codUnidMed">Código unidade medida</param>
        /// <returns>boolean</returns>
        public bool ProdutoHasUnidadeMedida(int codUnidMed)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            SqlDataReader rdr = null;

            int qtd = 0;

            try
            {
                String sql = "SELECT COUNT(*) AS QtdCodUnidMed FROM Produto WHERE CodUnidMed = @CodUnidMed";

                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandText = sql;

                cmd.Parameters.Add(new SqlParameter("@CodUnidMed", codUnidMed));

                rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    qtd = Convert.ToInt32(rdr["QtdCodUnidMed"].ToString());
                }

                if (qtd.Equals(0))
                {
                   return false;
                }
                else
                {
                    return  true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conn.Close();
                rdr.Close();
            }
        }
    }
}
