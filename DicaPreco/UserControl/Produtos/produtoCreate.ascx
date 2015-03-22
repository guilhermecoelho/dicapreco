<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="produtoCreate.ascx.cs" Inherits="DicaPreco.UserControl.Produtos.produtoCreate" %>

<div class="form-group">
    <div class="form-group">
        <label>Código</label>
        <asp:TextBox ID="txtCodigo" runat="server" TextMode="Number" class="form-control" Width="20%"></asp:TextBox>
    </div>
    <div class="form-group">
        <label>Descrição</label>
        <asp:TextBox ID="txtDescrição" runat="server" MaxLength="200" class="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Unidade de Medida</label>
        <asp:DropDownList ID="ddlUnidadeMedida" runat="server" class="form-control" Width="30%"></asp:DropDownList>
    </div>
</div>
