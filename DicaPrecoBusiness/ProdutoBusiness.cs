using DicaPrecoDAL;
using DicaPrecoEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicaPrecoBusiness
{
    public class ProdutoBusiness
    {
        /// <summary>
        /// Lista produtos filtrando pela descrição
        /// </summary>
        /// <param name="produto"> objeto produto</param>
        /// <returns>Lista de produtos</returns>
        public List<Produto> listaProdutos(Produto produto)
        {
            List<Produto> produtos = new List<Produto>();
            ProdutoDAL dal = new ProdutoDAL();

            produtos = dal.listaProdutos(produto);

            return produtos;
        }

        /// <summary>
        /// Lista produto pelo codigo
        /// </summary>
        /// <param name="codProd">código do produto</param>
        /// <returns>objeto produto</returns>
        public Produto listaProdutosByCodigo(int codProd)
        {
            ProdutoDAL dal = new ProdutoDAL();

            return dal.listaProdutosByCodigo(codProd);
        }

        /// <summary>
        /// Salva um novo produto ou atualiza caso seu código já exista
        /// </summary>
        /// <param name="produto">objeto produto</param>
        public bool SalvarProduto(Produto produto)
        {
            ProdutoDAL dal = new ProdutoDAL();

            return dal.SalvarProduto(produto);
        }
        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="codProd"> código do produto</param>
        public bool ExcluirProduto(int codProd)
        {
            ProdutoDAL dal = new ProdutoDAL();

            return dal.ExcluirProduto(codProd);
        }

        /// <summary>
        /// Verifica se o código a ser gravado já existe
        /// </summary>
        /// <param name="codUnidMed">código da unidadeMedida</param>
        /// <returns>Boolean</returns>
        public bool verificaExisteProduto(int codProd)
        {
            Produto produtoProcura = new Produto();
            ProdutoDAL dal = new ProdutoDAL();

            produtoProcura = dal.listaProdutosByCodigo(codProd);

            if (!produtoProcura.codUnidMed.Equals(0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
