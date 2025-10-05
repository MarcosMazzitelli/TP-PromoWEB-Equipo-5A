<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs"Inherits="PromoWeb.FormularioCliente"  UnobtrusiveValidationMode="None" %> 
<%-- Se agrega la linea: UnobtrusiveValidationMode="None" para evirar el error de Jquery--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container mt-4">
    <h3>Ingresá tus datos</h3>
 <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager> <!--Va previo al update panel para que no de error-->
 <asp:UpdatePanel ID="upCliente" runat="server" UpdateMode="Conditional">
 <ContentTemplate>
    <div class="row g-3">
        <div class="col-md-4">
            <label for="txtDocumento" class="form-label">Documento</label>
            <asp:TextBox runat="server" AutoPostBack="true" OnTextChanged="txtDocumento_TextChanged" ID="txtDocumento" CssClass="form-control"/>
            <asp:RequiredFieldValidator  runat="server" ControlToValidate="txtDocumento" ErrorMessage="El documento es obligatorio."  ForeColor="Red" />
            <asp:RegularExpressionValidator  runat="server" ControlToValidate="txtDocumento" ErrorMessage="Sólo números (entre 7 y 8 digitos)"  ValidationExpression="^\d{7,8}$" ForeColor="Red" />
        </div>
        <div class="col-md-4">
            <label for="txtNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            <asp:RequiredFieldValidator  runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." ForeColor="Red"/>
            <asp:RegularExpressionValidator  runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre solo puede contener letras." ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ForeColor="Red"/>
        </div>
        <div class="col-md-4">
            <label for="txtApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server"  ControlToValidate="txtApellido" ErrorMessage="El apellido es obligatorio."  ForeColor="Red" />
             <asp:RegularExpressionValidator  runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido solo puede contener letras." ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ForeColor="Red"/>
        </div>
        <div class="col-md-4">
            <label for="txtEmail" class="form-label">Email</label>
            <div class="input-group">
                <span class="input-group-text" id="inputGroupPrepend">@</span>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
            <asp:RequiredFieldValidator runat="server"  ControlToValidate="txtEmail" ErrorMessage="El email es obligatorio."  ForeColor="Red"/>
            <asp:RegularExpressionValidator runat="server"  ControlToValidate="txtEmail" ErrorMessage="Email inválido."  ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"  ForeColor="Red"  />
        </div>
        <div class="col-md-6">
            <label for="txtDireccion" class="form-label">Dirección</label>
            <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtDireccion" ErrorMessage="La dirección es obligatoria." ForeColor="Red"/>
        </div>
        <div class="col-md-3">
            <label for="txtCiudad" class="form-label">Ciudad</label>
            <asp:TextBox runat="server" ID="txtCiudad" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server"  ControlToValidate="txtCiudad" ErrorMessage="La ciudad es obligatoria."  ForeColor="Red" />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCiudad" ErrorMessage="La ciudad solo puede contener letras." ValidationExpression="^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$" ForeColor="Red" />
        </div>
        <div class="col-md-3">
            <label for="txtCP" class="form-label">CP</label>
            <asp:TextBox runat="server" ID="txtCP" CssClass="form-control" />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCP" ErrorMessage="El CP es obligatorio."  ForeColor="Red"/>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCP" ErrorMessage="Sólo números."  ValidationExpression="^\d+$" ForeColor="Red" />
        </div>
        <div class="col-12">
           <asp:CheckBox ID="chkAceptar" runat="server"/>
           <asp:Label ID="lblAceptar" runat="server" AssociatedControlID="chkAceptar" CssClass="form-check-label">Acepte términos y condiciones</asp:Label>  
           <asp:CustomValidator ID="cvAceptar" runat="server" ErrorMessage="Debes aceptar los términos y condiciones." ForeColor="Red" OnServerValidate="cvAceptar_ServerValidate"/>
        </div>
        <div class="col-12">
            <asp:Button Text="Participar!" ID="BtnParticipar" OnClick="BtnParticipar_Click" runat="server" class="btn btn-primary" CausesValidation="true"/>
        </div>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div> 
</asp:Content> 