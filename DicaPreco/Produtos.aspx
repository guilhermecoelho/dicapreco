<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="DicaPreco.Produtos" %>
<%@ Register src="UserControl/Produtos/produtoList.ascx" tagname="produtoList" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="page-header">
        <div>
            <label><h3>Produtos</h3></label>
        </div>
    </div>
    <uc1:produtoList ID="produtoList1" runat="server" />
</asp:Content>
