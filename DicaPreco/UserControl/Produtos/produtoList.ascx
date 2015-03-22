<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="produtoList.ascx.cs" Inherits="DicaPreco.UserControl.Produtos.produtoList" %>

<%@ Register Src="produtoCreate.ascx" TagName="produtoCreate" TagPrefix="uc2" %>


<asp:MultiView ID="mvwProduto" runat="server" ActiveViewIndex="0">

    <asp:View ID="vwLista" runat="server">
        <div class="form-group">
            <div class="form-group">
                <label>Pesquisar</label>
                <asp:TextBox ID="txtPesquisar" runat="server" class="form-control"></asp:TextBox>
            </div>
            <input id="btnPesquisar" type="button" value="pesquisar" runat="server" onserverclick="btnPesquisar_click" class="btn btn-default" />
            <input id="btnNovo" type="button" value="novo" runat="server" onserverclick="btnNovo_click" class="btn btn-default" />
        </div>

        <asp:GridView ID="gvwProduto" AutoGenerateColumns="false" runat="server" DataKeyNames="codProd" OnRowEditing="gvwProduto_RowEditing" OnRowDeleting="gvwProduto_RowDeleting" CssClass="table table-hover table-striped table-bordered">
            <Columns>
                <asp:TemplateField HeaderText="Código" HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <%# Eval("codProd")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descrição" HeaderStyle-Width="42%">
                    <ItemTemplate>
                        <%# Eval("descrProd")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descrição unidade" HeaderStyle-Width="42%">
                    <ItemTemplate>
                        <%# Eval("descrUnidMed")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Editar" HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <div align="center">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-info" CommandName="Edit" CausesValidation="false" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Excluir" HeaderStyle-Width="5%">
                    <ItemTemplate>
                        <div align="center">
                            <asp:Button ID="btnExcluir" runat="server" Text="Excluir" CssClass="btn btn-danger" CommandName="Delete" CausesValidation="false" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:View>
    <asp:View ID="vwProdutoCadastro" runat="server">
        <uc2:produtoCreate ID="produtoCreate1" runat="server" />
        <input id="btnSalvar" type="button" value="Salvar" runat="server" onserverclick="btnSalvar_click" visible="false"  class="btn btn-default"/>
        <input id="btnAtualizar" type="button" value="Atualizar" runat="server" onserverclick="btnAtualizar_click" visible="false"  class="btn btn-default"/>
        <input id="btnVoltar" type="button" value="Voltar" runat="server" onserverclick="btnVoltar_click" visible="true"  class="btn btn-default"/>
    </asp:View>
</asp:MultiView>
