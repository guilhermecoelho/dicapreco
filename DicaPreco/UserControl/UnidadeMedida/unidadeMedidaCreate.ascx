<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="unidadeMedidaCreate.ascx.cs" Inherits="DicaPreco.UserControl.UnidadeMedida.unidadeMedidaCreate" %>

<div class="form-group">
    <div class="form-group">
        <label>Código</label>
        <asp:TextBox ID="txtCodigo" runat="server" class="form-control"  Width="20%" TextMode="Number"></asp:TextBox>
    </div>

    <div class="form-group">
        <label>Descrição</label>
        <asp:TextBox ID="txtDescrição" runat="server" class="form-control" MaxLength="30"></asp:TextBox>
    </div>
</div>
