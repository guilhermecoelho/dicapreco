using DicaPrecoBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DicaPreco.UserControl.Produtos
{
    public partial class produtoCreate : System.Web.UI.UserControl
    {
        #region .:property da classe:.

        private DicaPrecoEntity.Produto produto = new DicaPrecoEntity.Produto();

        public DicaPrecoEntity.Produto Produto
        {
            get
            {
                produto = (DicaPrecoEntity.Produto)this.ViewState["produto"];
                if (produto == null)
                    produto = new DicaPrecoEntity.Produto();
                return produto;
            }
            set
            {
                produto = value;
                this.ViewState["produto"] = value;
                PopulaDados();
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaDropDown();
            }
        }

        #region metodos

        private void carregaDropDown()
        {
            List<DicaPrecoEntity.UnidadeMedida> unidadeMedidaList = new List<DicaPrecoEntity.UnidadeMedida>();
            DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            unidadeMedidaList = business.listaUnidadesMedida(unidadeMedida);

            ddlUnidadeMedida.DataSource = unidadeMedidaList;
            ddlUnidadeMedida.DataTextField = "DescrUnidMed";// Visualização
            ddlUnidadeMedida.DataValueField = "CodUnidMed"; //Valor

            ddlUnidadeMedida.DataBind();
            ddlUnidadeMedida.Items.Insert(0, new ListItem("Selecione", "0"));
        }

        public void salvar(bool isNovo)
        {
            DicaPrecoEntity.Produto Produto = new DicaPrecoEntity.Produto();
            ProdutoBusiness business = new ProdutoBusiness();

            Produto.codProd = Convert.ToInt32(txtCodigo.Text);
            Produto.descrProd = txtDescrição.Text;
            Produto.codUnidMed = Convert.ToInt32(ddlUnidadeMedida.SelectedValue);

            if (isNovo)
            {
                if (business.verificaExisteProduto(Produto.codProd))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "existente", "alert('Já existem uma produto com o código digitado ')", true);
                }
                else
                {
                    salvarNoBanco(Produto);
                }
            }
            else
            {
                salvarNoBanco(Produto);
            }
        }

        private void salvarNoBanco(DicaPrecoEntity.Produto Produto)
        {
            ProdutoBusiness business = new ProdutoBusiness();

            if (business.SalvarProduto(Produto))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "sucesso", "alert('Produto salvo com sucesso')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "erro", "alert('Erro ao salvar produto')", true);
            }
        }

        private void PopulaDados()
        {
            produto = this.Produto;

            txtCodigo.Text = produto.codProd.ToString();
            txtDescrição.Text = produto.descrProd;
            ddlUnidadeMedida.SelectedValue = produto.codUnidMed.ToString();
        }
        #endregion
    }
}