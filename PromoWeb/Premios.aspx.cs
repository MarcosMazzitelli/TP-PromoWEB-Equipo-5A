using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace PromoWeb
{
    public partial class Premios : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public List<Imagen> ListaImagenes { get; set; }
        public List<Imagen> imagenesPorArticulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                ImagenNegocio imagenNegocio = new ImagenNegocio();
                //Se carga en memoria la property publica ListaArticulos e imagenes para poder usarla en el front
                ListaArticulos = articuloNegocio.listar();
                ListaImagenes = imagenNegocio.listar();

                if (IsPostBack) //El evento del boton genera un postback, por lo que lo manipulamos dentro de este IF.
                {
                    /*Documentacion objeto REQUEST (QueryString, Form y Cookies) https://learn.microsoft.com/es-es/aspnet/web-pages/overview/getting-started/introducing-aspnet-web-pages-2/form-basics */
                    string articuloSeleccionado = Request.Form["btnElegirPremio"]; //obtiene una coleccion de variables del formulario, en este caso solo la del btnElegirPremio

                    if (!string.IsNullOrEmpty(articuloSeleccionado))
                    {
                        int idArticulo = int.Parse(articuloSeleccionado);
                        Response.Redirect("FormularioCliente.aspx?id=" + idArticulo, false);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", "Error al cargar la página de premios" + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}