<%@ Page Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="UnidadeMedida.aspx.cs" Inherits="DicaPreco.UnidadeMedida" %>

<%@ Register Src="~/UserControl/UnidadeMedida/unidadeMedidaList.ascx" TagPrefix="uc1" TagName="unidadeMedidaList" %>

<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div class="page-header">
        <div>
            <label><h3>Unidades de Medidas</h3></label>
        </div>
    </div>
    <uc1:unidadeMedidaList runat="server" ID="unidadeMedidaList" />
</asp:Content>



