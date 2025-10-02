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
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            
            //Se carga en memoria la property publica ListaArticulos e imagenes para poder usarla en el front
            ListaArticulos = articuloNegocio.listar(); 
            ListaImagenes = imagenNegocio.listar();

        }

        public string ImagenUrl(List<Imagen> imagenesPorArticulo)
        {
            if(imagenesPorArticulo != null && imagenesPorArticulo.Count > 0)
            {
                return imagenesPorArticulo[0].ImagenUrl;
            }
            //imagen por defecto (placeholder)
            return "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSUwCJYSnbBLMEGWKfSnWRGC_34iCCKkxePpg&s";
        }
    }
}