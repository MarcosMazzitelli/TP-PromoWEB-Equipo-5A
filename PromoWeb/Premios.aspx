<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Premios.aspx.cs" Inherits="PromoWeb.Premios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Ventana de premios!</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%
            /*foreach que genera una tarjeta por cada articulo dentro de la lista*/
            foreach (dominio.Articulo articulo in ListaArticulos)
            {

                imagenesPorArticulo = ListaImagenes.FindAll(img => img.IdArticulo == articulo.Id);
                string idCarousel = "idCarousel" + articulo.Id;
        %>
        <div class="col">
            <div class="card h-100">
                <!---  carrusel dinamico dentro de cada tarjeta-->
                <div id="<%:idCarousel %>" class="carousel slide">
                    <div class="carousel-indicators">
                        <%
                            /*FOR de indicadores (botones) que marcan cuantas imagenes hay y permiten clickear para ir directo a una posicion especifica)*/
                            for (int i = 0; i < imagenesPorArticulo.Count; i++)
                            {

                        %>
                        <button type="button" data-bs-target="#<%:idCarousel %>" data-bs-slide-to="<%:i %>" class="<%: (i == 0 ? "active" : "") %>" aria-current="<%: (i == 0 ? "true" : "false") %>" aria-label="Slide <%: (i + 1) %>"></button>
                        <%
                            }
                        %>
                    </div>
                    <div class="carousel-inner">
                        <%
                            /*FOR de Slides (imagenes) renderea cada imagen que se encuentra dentro de la lista*/
                            for (int i = 0; i < imagenesPorArticulo.Count; i++)
                            {
                        %>
                        <div class='carousel-item <%: (i == 0 ? "active" : "") %>'>
                            <img src='<%: imagenesPorArticulo[i].ImagenUrl %>'
                                class="d-block w-100"
                                alt='Imagen de <%: articulo.Nombre %>'>
                        </div>
                        <%
                            }
                        %>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#<%:idCarousel %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Anterior</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#<%:idCarousel %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Siguiente</span>
                    </button>
                </div>
                <div class="card-body">
                    <h5 class="card-title"><%: articulo.Nombre %></h5>
                    <p class="card-text"><%: articulo.Descripcion %></p>
                    <button type="submit" name="btnElegirPremio" value="<%: articulo.Id %>" class="btn btn-primary">Seleccionar </button>
                </div>
            </div>
        </div>
        <%
            }
        %>
    </div>
</asp:Content>
