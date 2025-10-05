using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoWeb
{
    public partial class VentanaFinal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string codigoVoucher;
                    bool registrado;


                    if (Session["codigoVoucher"] != null)
                    {
                        codigoVoucher = Session["codigoVoucher"].ToString();
                        lblCodigoVoucher.Text = codigoVoucher;
                    }
                    else
                    {
                        lblCodigoVoucher.Text = "No disponible";
                    }
                    
           
                    if (Session["registrado"] != null)
                    {
                        registrado = (bool)Session["registrado"];

                        if(registrado)
                        {
                            lblMensajeExito.Text = "Cliente registardo correctamente";
                            lblMensajeExito.Visible = true;
                        }
                    }
                    if (Session["nombreArticulo"] != null)
                    {
                        string nombreArticulo = Session["nombreArticulo"].ToString();
                        lblNombreArticulo.Text = nombreArticulo;
                    }
                    else
                    {
                        lblNombreArticulo.Text = "No disponible";
                    }
                        Cliente cliente = (Cliente)Session["cliente"];

                    if (cliente != null && !string.IsNullOrEmpty(cliente.Nombre))
                    {
                        lblNombreUsuario.Text = cliente.Nombre;
                    }
                    else
                    {
                        lblNombreUsuario.Text = "No disponible";
                    }
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al cargar la ventana final" + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}