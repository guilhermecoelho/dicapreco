using DicaPrecoBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DicaPrecoEntity;

namespace DicaPreco.UserControl.UnidadeMedida
{
    public partial class unidadeMedidaList : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region botões

        public void btnPesquisar_click(object sender, EventArgs e)
        {
            List<DicaPrecoEntity.UnidadeMedida> unidadeMedidaLista = new List<DicaPrecoEntity.UnidadeMedida>();
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();
            DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();

            unidadeMedida.descrUnidMed = txtPesquisar.Text;


            loadGrid(unidadeMedida);
        }

        public void btnNovo_click(object sender, EventArgs e)
        {
            btnSalvar.Visible = true;
            btnAtualizar.Visible = false;

            unidadeMedidaCreate.UnidadeMedida = new DicaPrecoEntity.UnidadeMedida();

            mvwUnidadeMedida.ActiveViewIndex = 1;
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
            mvwUnidadeMedida.ActiveViewIndex = 0;
        }

        #endregion

        #region Grid

        private void loadGrid(DicaPrecoEntity.UnidadeMedida unidadeMedida)
        {
            List<DicaPrecoEntity.UnidadeMedida> unidadeMedidaLista = new List<DicaPrecoEntity.UnidadeMedida>();
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            unidadeMedidaLista = business.listaUnidadesMedida(unidadeMedida);

            gvwUnidadeMedida.DataSource = unidadeMedidaLista;
            gvwUnidadeMedida.DataBind();
        }

        protected void gvwUnidadeMedida_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            Int32 codUnidMed = (Int32)gvwUnidadeMedida.DataKeys[e.RowIndex].Value;
            if (business.ProdutoHasUnidadeMedida(codUnidMed))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "erro", "alert('Unidade de medida relacionada a produtos')", true);
            }
            else
            {
                if (business.ExcluirUnidadeMedida(codUnidMed))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "sucesso", "alert('Unidade de medida excluida com sucesso')", true);
                    loadGrid(unidadeMedida);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "erro", "alert('Não foi possivel excluir a unidade')", true);
                }
            }
        }

        protected void gvwUnidadeMedida_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DicaPrecoEntity.UnidadeMedida unidadeMedidaLista = new DicaPrecoEntity.UnidadeMedida();

            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            Int32 codUnidMed = (Int32)gvwUnidadeMedida.DataKeys[e.NewEditIndex].Value;

            unidadeMedidaLista = business.listaUnidadeMedidaByCodigo(codUnidMed);
            unidadeMedidaCreate.UnidadeMedida = unidadeMedidaLista;

            btnSalvar.Visible = false;
            btnAtualizar.Visible = true;

            mvwUnidadeMedida.ActiveViewIndex = 1;
        }

        #endregion

        #region metodos

        private void salvar(bool isNovo)
        {
            DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();

            unidadeMedidaCreate.salvar(isNovo);
            mvwUnidadeMedida.ActiveViewIndex = 0;
            loadGrid(unidadeMedida);
        }
        #endregion
    }
}