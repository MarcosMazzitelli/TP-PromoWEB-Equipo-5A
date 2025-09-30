<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PromoWeb.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-4"></div>
        <div class="col">
            <div class="mb-3">
                <div class="alert alert-warning" role="alert" id="alertWarning1" runat="server" visible="false">
                    El código ingresado no existe. Intente con uno válido.
                </div>
                <div class="alert alert-warning" role="alert" id="alertWarning2" runat="server" visible="false">
                    El código ingresado ya fue reclamado. Por favor intente con otro.
                </div>
                <div class="alert alert-danger" role="alert" id="alertDanger" runat="server" visible="false">
                    Error de sistema.
                </div>
            </div>

            <div class="mb-3">
                <label for="txtVoucher" class="form-label">Ingresá el código de tu voucher!</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtVoucher" placeholder="XXXXXXXXXXXXXXX" />
            </div>
            <asp:Button Text="Siguiente" CssClass="btn btn-primary" ID="btnSiguiente" OnClick="btnSiguiente_Click" runat="server" />
        </div>
        <div class="col-4"></div>
    </div>
</asp:Content>
