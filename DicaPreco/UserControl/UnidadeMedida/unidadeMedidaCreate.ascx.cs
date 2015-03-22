using DicaPrecoBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DicaPreco.UserControl.UnidadeMedida
{
    public partial class unidadeMedidaCreate : System.Web.UI.UserControl
    {
        #region .:property da classe:.

        private DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();

        public DicaPrecoEntity.UnidadeMedida UnidadeMedida
        {
            get
            {
                unidadeMedida = (DicaPrecoEntity.UnidadeMedida)this.ViewState["unidadeMedida"];
                if (unidadeMedida == null)
                    unidadeMedida = new DicaPrecoEntity.UnidadeMedida();
                return unidadeMedida;
            }
            set
            {
                unidadeMedida = value;
                this.ViewState["unidadeMedida"] = value;
                PopulaDados();
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region metodos

        public void salvar(bool isNovo)
        {
            DicaPrecoEntity.UnidadeMedida unidadeMedida = new DicaPrecoEntity.UnidadeMedida();
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            unidadeMedida.codUnidMed = Convert.ToInt32(txtCodigo.Text);
            unidadeMedida.descrUnidMed = txtDescrição.Text;

            if (isNovo)
            {
                if (business.verificaExisteUnidadeMedida(unidadeMedida.codUnidMed))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "existente", "alert('Já existem uma unidade de medida com o código digitado ')", true);
                }
                else
                {
                    salvarNoBanco(unidadeMedida);
                }
            }
            else
            {
                salvarNoBanco(unidadeMedida);
            }
        }

        private void salvarNoBanco(DicaPrecoEntity.UnidadeMedida unidadeMedida)
        {
            UnidadeMedidaBusiness business = new UnidadeMedidaBusiness();

            if (business.SalvarUnidadeMedida(unidadeMedida))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "sucesso", "alert('Unidade de medida salva com sucesso')", true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "erro", "alert('Erro ao salvar unidade de medida')", true);
            }
        }

        private void PopulaDados()
        {
            unidadeMedida = this.UnidadeMedida;

            txtCodigo.Text = unidadeMedida.codUnidMed.ToString();
            txtDescrição.Text = unidadeMedida.descrUnidMed;
        }

        #endregion
    }
}