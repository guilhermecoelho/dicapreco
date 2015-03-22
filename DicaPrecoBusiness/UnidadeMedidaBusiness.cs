using DicaPrecoDAL;
using DicaPrecoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicaPrecoBusiness
{
    public class UnidadeMedidaBusiness
    {
        /// <summary>
        /// Lista unidades de medida
        /// </summary>
        /// <param name="unidadeMedida">objeto unidadeMedida</param>
        /// <returns>Lista objeto unidadeMedida</returns>
        public List<UnidadeMedida> listaUnidadesMedida(UnidadeMedida unidadeMedida)
        {
            List<UnidadeMedida> unidadeMedidas = new List<UnidadeMedida>();
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            unidadeMedidas = dal.listaUnidadesMedida(unidadeMedida);

            return unidadeMedidas;
        }

        /// <summary>
        /// Lista unidadeMedida pelo código 
        /// </summary>
        /// <param name="codUnidMed">código unidadeMedida</param>
        /// <returns>Objeto unidadeMedida</returns>
        public UnidadeMedida listaUnidadeMedidaByCodigo(int codUnidMed)
        {
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            return dal.listaUnidadeMedidaByCodigo(codUnidMed);
        }

        /// <summary>
        /// Salva um novo produto ou atualiza caso seu código já exista
        /// </summary>
        /// <param name="unidadeMedida">objeto unidadeMedida</param>
        public bool SalvarUnidadeMedida(UnidadeMedida unidadeMedida)
        {
            UnidadeMedida unidadeMedidaProcura = new UnidadeMedida();
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            unidadeMedidaProcura = dal.listaUnidadeMedidaByCodigo(unidadeMedida.codUnidMed);
            return dal.SalvarUnidadeMedida(unidadeMedida);

        }

        /// <summary>
        /// Verifica se o código a ser gravado já existe
        /// </summary>
        /// <param name="codUnidMed">código da unidadeMedida</param>
        /// <returns>Boolean</returns>
        public bool verificaExisteUnidadeMedida(int codUnidMed)
        {
            UnidadeMedida unidadeMedidaProcura = new UnidadeMedida();
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            unidadeMedidaProcura = dal.listaUnidadeMedidaByCodigo(codUnidMed);

            if (!unidadeMedidaProcura.codUnidMed.Equals(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Exclui uma unidade de medida
        /// </summary>
        /// <param name="codUnidMed">código da unidade de medida</param>
        public bool ExcluirUnidadeMedida(int codUnidMed)
        {
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            return dal.ExcluirUnidadeMedida(codUnidMed);
        }

        public bool ProdutoHasUnidadeMedida(int codUnidMed)
        {
            UnidadeMedidaDAL dal = new UnidadeMedidaDAL();

            return dal.ProdutoHasUnidadeMedida(codUnidMed);
        }
    }
}
