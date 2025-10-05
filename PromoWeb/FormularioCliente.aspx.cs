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
  
    public partial class FormularioCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            string nombreArticulo;

            string idArticulo = Request.QueryString["id"]; //guardo el Id que viaja por URL en una variable
            if (!string.IsNullOrEmpty(idArticulo))
            {
                int idArt = int.Parse(idArticulo);
                Session["idArticulo"] = idArticulo; // lo guardo en Session para usarla despues
                nombreArticulo = articuloNegocio.buscarNombreArticulo(idArt);
                Session["nombreArticulo"] = nombreArticulo;
            }
            
        }
        protected void cvAceptar_ServerValidate(object source, ServerValidateEventArgs args) 
        {
            args.IsValid = chkAceptar.Checked; //si el usuario apreto o no devuelve true o false para validar
        }

        protected void cvEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();

            bool emailValido = clienteNegocio.validarEmail(txtEmail.Text); // Validar el email con el metodo agregado en ClienteNegocio

            args.IsValid = emailValido; // True = Válido, False = No válido
        }


        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
         
            if (!Page.IsValid) //no ejecuta el siguiente codigo salvo que la pagina si sea valida (validadores)
            {
                return;
            }

            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                VoucherNegocio voucherNegocio = new VoucherNegocio();
                Cliente cliente = new Cliente();
                Voucher voucher = new Voucher();
                string codigoVoucher;


                cliente = clienteNegocio.buscarClienteDni(txtDocumento.Text);//se busca el cliente por documento en BD


                if (Session["codigoVoucher"] != null)
                {
                    codigoVoucher = Session["codigoVoucher"].ToString(); //Traemos el codigo de voucher cargado en la session
                }
                else
                {
                    Session.Add("error", "No se encontró el código de voucher");
                    Response.Redirect("Error.aspx", false);
                    return;

                }

                if (cliente == null) //meteodo para registrar cliente
                {

                    Session["registrado"] = true; //guardo en la session si es cliente nuevo o no para el mensaje de exito en la ventana final
                    cliente = new Cliente();

                    cliente.Documento = txtDocumento.Text;
                    cliente.Nombre = txtNombre.Text;
                    cliente.Apellido = txtApellido.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Direccion = txtDireccion.Text;
                    cliente.Ciudad = txtCiudad.Text;
                    cliente.CP = int.Parse(txtCP.Text);

                    cliente.Id = clienteNegocio.agregarCliente(cliente); //se agrega registro nuevo cliente a la BD y traigo su Id autonunmérico para luego settear al voucher
                }
                else
                {
                    Session["registrado"] = false; //si no es nuevo cliente queda en false
                }

                int idArticulo = 0;
                if (Session["idArticulo"] != null)
                {
                    idArticulo = int.Parse(Session["idArticulo"].ToString()); //traemos el id viajaba desde Premio por URL, que luego guardamos en session en el Load. 
                }

                voucher.IdCliente = cliente.Id;
                voucher.FechaCanje = DateTime.Now; //toma el valor del momento del dia en el que se ejecuta el ingreso del voucher
                voucher.IdArticulo = idArticulo;
                voucher.CodigoVoucher = codigoVoucher;
                voucherNegocio.modificar(voucher);
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

                Session["cliente"] = cliente; // Gurdamos en session los datos que necesitamos para la ventana final
                Response.Redirect("VentanaFinal.aspx", false);
                return;

            }
            catch (Exception ex)
            {

                Session.Add("error", "Error al participar " + ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e) //funcion con AutoPostBack para poder capturar el evento del cambio de contenido en el textbox
        {
           
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
          
            cliente = clienteNegocio.buscarClienteDni(txtDocumento.Text);//se busca en la BD si el documento ingresado se encuentra registrado
            if (cliente != null) //si esta registrado, traigo todos los valores a su textBox
            {
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCP.Text = cliente.CP.ToString();
                
                txtNombre.Enabled = false; //de esta manera quitamos la posibilidad de modificar los valores registados en la BD
                txtApellido.Enabled = false;
                txtEmail.Enabled = false;
                txtDireccion.Enabled = false;
                txtCiudad.Enabled = false;
                txtCP.Enabled = false;
            }else 
            {  
                txtNombre.Text = ""; //si no se encuentra el dni en la BD se setean todos los textBox vacíos
                txtApellido.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtCP.Text = "";
                
                txtNombre.Enabled = true; //se habilita nuevamente la posibilidad de escribir en los textBox
                txtApellido.Enabled = true;
                txtEmail.Enabled = true;
                txtDireccion.Enabled = true;
                txtCiudad.Enabled = true;
                txtCP.Enabled = true;
            }
        }
    }
}