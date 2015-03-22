using DicaPrecoBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace DicaPreco.UserControl.Produtos
{
    public partial class produtoList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        #region botões

        public void btnPesquisar_click(object sender, EventArgs e)
        {
            List<DicaPrecoEntity.Produto> ProdutoLista = new List<DicaPrecoEntity.Produto>();
            ProdutoBusiness business = new ProdutoBusiness();
            DicaPrecoEntity.Produto Produto = new DicaPrecoEntity.Produto();

            Produto.descrProd = txtPesquisar.Text;
            loadGrid(Produto);
        }

        public void btnNovo_click(object sender, EventArgs e)
        {
            btnSalvar.Visible = true;
            btnAtualizar.Visible = false;

            produtoCreate1.Produto = new DicaPrecoEntity.Produto();

            mvwProduto.ActiveViewIndex = 1;
        }

        public void btnSalvar_click(object sender, EventArgs e)
        {
            salvar(true);
        }

        public void btnAtualizar_click(object sender, EventArgs e)
        {
            salvar(false);
        }

        public void btnVoltar_click(object sender, EventArgs e)
        {
            mvwProduto.ActiveViewIndex = 0;
        }

        #endregion

        #region Grid

        private void loadGrid(DicaPrecoEntity.Produto Produto)
        {
            List<DicaPrecoEntity.Produto> ProdutoLista = new List<DicaPrecoEntity.Produto>();
            ProdutoBusiness business = new ProdutoBusiness();

            ProdutoLista = business.listaProdutos(Produto);

            gvwProduto.DataSource = ProdutoLista;
            gvwProduto.DataBind();
        }

        protected void gvwProduto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DicaPrecoEntity.Produto Produto = new DicaPrecoEntity.Produto();
            ProdutoBusiness business = new ProdutoBusiness();

            Int32 codUnidMed = (Int32)gvwProduto.DataKeys[e.RowIndex].Value;

            if (business.ExcluirProduto(codUnidMed))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "sucesso", "alert('Produto excluida com sucesso')", true);
                loadGrid(Produto);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "erro", "alert('Não foi possivel excluir o produto')", true);
            }

        }

        protected void gvwProduto_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DicaPrecoEntity.Produto ProdutoLista = new DicaPrecoEntity.Produto();

            ProdutoBusiness business = new ProdutoBusiness();

            Int32 codProd = (Int32)gvwProduto.DataKeys[e.NewEditIndex].Value;

            ProdutoLista = business.listaProdutosByCodigo(codProd);
            produtoCreate1.Produto = ProdutoLista;

            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;

            mvwProduto.ActiveViewIndex = 1;
        }

        #endregion

        #region metodos

        private void salvar(bool isNovo)
        {
            DicaPrecoEntity.Produto Produto = new DicaPrecoEntity.Produto();

            produtoCreate1.salvar(isNovo);
            mvwProduto.ActiveViewIndex = 0;
            loadGrid(Produto);
        }

        #endregion
    }
}