using dominio;
using negocio;
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
                    bool registrado;

                    string codigoVoucher = "No disponible";
                    if (Session["codigoVoucher"] != null)
                    {
                        codigoVoucher = Session["codigoVoucher"].ToString();
                        lblCodigoVoucher.Text = codigoVoucher;
                    }
                    lblCodigoVoucher.Text = codigoVoucher;


                    if (Session["registrado"] != null)
                    {
                        registrado = (bool)Session["registrado"];

                        if (registrado)
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

                    try
                    {
                        EmailService email = new EmailService();

                        // Guardo los campos necesarios para el mail personalizado
                        string nombreArticulo = Session["nombreArticulo"].ToString();
                        string nombreCliente = cliente.Nombre;
                        string apellidoCliente = cliente.Apellido;
                        string emailCliente = cliente.Email;

                        string cuerpo = $@"
                        <html>
                          <body style='font-family: Arial, sans-serif; background-color:#f5f5f5; padding:20px; color:#000 !important;'>
                            <div style='max-width:600px; margin:auto; background:#fff; border:1px solid #ddd; border-radius:8px; padding:20px; color:#000 !important;'>
                              <h2 style='text-align:center; color:#000 !important;'>Gracias por participar, {nombreCliente} {apellidoCliente}</h2>
                              <p style='color:#000 !important;'>Tu canje del artículo <b style=""color:#000 !important;"">{nombreArticulo}</b> se registró correctamente.</p>
                              <p style='color:#000 !important;'>Tu código de voucher es:</p>
                              <p style='font-size:20px; font-weight:bold; text-align:center; margin:15px 0; color:#000 !important;'>{codigoVoucher}</p>
                              <hr style='border:none; border-top:1px solid #eee; margin:20px 0;'/>
                              <p style='font-size:12px; color:#000 !important; text-align:center;'>
                                Este mensaje fue generado automáticamente por <b style=""color:#000 !important;"">PromoWeb</b>.<br/>
                                Por favor, no respondas a este correo.
                              </p>
                            </div>
                          </body>
                        </html>";

                        email.armarCorreo(emailCliente, "Cupon reclamado - PromoWebApp", cuerpo); // Se arma al estructura del correo
                        email.enviarEmail(); // Se envia el correo al email del cliente agregado o modificado
                    }
                    catch (Exception ex)
                    {

                        Session.Add("error", "Error al enviar el email" + ex.ToString());
                        Response.Redirect("Error.aspx", false);
                        return;
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