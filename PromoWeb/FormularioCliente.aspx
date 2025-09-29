<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="PromoWeb.FormularioCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="row g-3 needs-validation" novalidate>
  <div class="col-md-4">
    <label for="validationCustom01" class="form-label">Nombre</label>
    <input type="text" class="form-control" id="validationCustom01" value="Marcos" required>
    <div class="valid-feedback">
      Perfecto
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustom02" class="form-label">Apellido</label>
    <input type="text" class="form-control" id="validationCustom02" value="García" required>
    <div class="valid-feedback">
      Perfecto
    </div>
  </div>
  <div class="col-md-4">
    <label for="validationCustomUsername" class="form-label">Email</label>
    <div class="input-group has-validation">
      <span class="input-group-text" id="inputGroupPrepend">@</span>
      <input type="text" class="form-control" id="validationCustomUsername" aria-describedby="inputGroupPrepend" required>
      <div class="invalid-feedback">
        Por favor ingrese Email
      </div>
    </div>
  </div>
  <div class="col-md-6">
    <label for="validationCustom03" class="form-label">Dirección</label>
    <input type="text" class="form-control" id="validationCustom03" required>
    <div class="invalid-feedback">
      Por Favor ingrese una dirección
    </div>
  </div>
 <div class="col-md-6">
   <label for="validationCustom03" class="form-label">Ciudad</label>
   <input type="text" class="form-control" id="validationCustom03" required>
   <div class="invalid-feedback">
     Por Favor ingrese una dirección
   </div>
 </div>
  <div class="col-md-3">
    <label for="validationCustom05" class="form-label">Codigo Postal</label>
    <input type="text" class="form-control" id="validationCustom05" required>
    <div class="invalid-feedback">
      Po Favor ingrese Codigo Postal
    </div>
  </div>
  <div class="col-12">
    <div class="form-check">
      <input class="form-check-input" type="checkbox" value="" id="invalidCheck" required>
      <label class="form-check-label" for="invalidCheck">
        Acepte terminos y condiciones
      </label>
      <div class="invalid-feedback">
        Debes estar de acuerdo al aceptar
      </div>
    </div>
  </div>
  <div class="col-12">
    <button class="btn btn-primary" type="submit">Participar!</button>
  </div>
</form>
</asp:Content>
