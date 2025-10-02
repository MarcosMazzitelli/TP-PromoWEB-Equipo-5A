<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="PromoWeb.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-4">
    <h3>Ingresá tus datos</h3>
         <div class="row g-3">
            <div class ="row mt-3">
                <div class="col-md-4">
                    <label for ="txtDocumento" class="form-label">Documento</label>
                    <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtDocumento_TextChanged" ID="txtDocumento" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-4">
                <label for ="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="col-md-4">
                <label for ="txtApellido" class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            </div>
            <div class="col-md-4">
                <label for ="txtEmail" class="form-label">Email</label>
                <div class="input-group">
                    <span class="input-group-text" id="inputGroupPrepend">@</span>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
                </div>
            </div>
            <div class="col-md-6">
                <label for ="txtDireccion" class="form-label">Dirección</label>
                <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label for ="txtCiudad" class="form-label">Ciudad</label>
                <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
            </div>
            <div class="col-md-3">
                <label for ="txtCP" class="form-label">CP</label>
                <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
            </div>
            <div class="col-12">
                <asp:CheckBox ID="chkAceptar" runat="server"/>
                <asp:Label ID="lblAceptar" runat="server" AssociatedControlID="chkAceptar" CssClass="form-check-label">Acepte términos y condiciones</asp:Label>  
            </div>
            <div class="col-12">
                <asp:Button Text ="Participar!" ID="BtnParticipar" OnClick="BtnParticipar_Click" runat ="server" class="btn btn-primary" />
            </div>
    </div>
</div>

</asp:Content>
