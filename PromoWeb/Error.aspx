<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PromoWeb.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2 class="mb-3">¡Error!</h2>
    </div>
    <div>
        <asp:Label ID="lblError" runat="server" Text="text"></asp:Label>
    </div>
    <div>
        <a href="Default.aspx" class="btn btn-primary mt-3">Volver al inicio</a>
    </div>
</asp:Content>
