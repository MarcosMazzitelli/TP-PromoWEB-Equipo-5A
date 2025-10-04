<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentanaFinal.aspx.cs" Inherits="PromoWeb.VentanaFinal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 d-flex justify-content-center">
        <div class="card text-center shadow-lg" style="max-width: 500px;">
            <div class="card-body">
                <h5 class="card-title mb-4 alert alert-success d-inline-block fs-6" >¡Participación registrada!</h5>
                <p class="card-text">
                    El cliente ya se encuentra participando por el premio.
                </p>
                <div class="mb-2">
                    <label class="form-label fw-bold">Nombre del Cliente:</label>
                    <asp:Label ID="lblNombreUsuario" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>

                <div class="mb-2">
                    <label class="form-label fw-bold">Código del Voucher:</label>
                    <asp:Label ID="lblCodigoVoucher" runat="server" CssClass="form-control-plaintext"></asp:Label>
                </div>
                   
                <div class="mb-3">
                     <asp:Label ID="lblMensajeExito" runat="server" CssClass="alert alert-light d-inline-block fs-8" Visible="false"></asp:Label>
                </div>

                <asp:Button Text="Vovler al inicio" ID="BtnParticipar" OnClick="BtnVolver_Click" runat="server" class="btn btn-primary" CausesValidation="true"/>
            </div>
        </div>
    </div>
</asp:Content>
