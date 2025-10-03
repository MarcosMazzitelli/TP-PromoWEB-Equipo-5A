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
         
        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
       

            ClienteNegocio clienteNegocio = new ClienteNegocio();
            VoucherNegocio voucherNegocio = new VoucherNegocio();
            
            Cliente cliente = clienteNegocio.buscarClienteDni(txtDocumento.Text);//se busca el cliente por documento en BD

            if(cliente == null)//si no se encontro procedo a setear los valores ingresados en el textBox para luego impactar el registro en la BD
            {
                cliente = new Cliente();
           
                cliente.Documento = txtDocumento.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Ciudad = txtCiudad.Text;
                int cp = 0;                           //cliente.CP = int.Parse(txtCP.Text); lanzaba un error al ejecutarse 
                int.TryParse(txtCP.Text, out cp);
                cliente.CP = cp;

                cliente.Id = clienteNegocio.agregarCliente(cliente); //se agrega registro nuevo cliente a la BD y traigo su Id autonunmérico para luego settear al voucher
            }
                //string codigoVoucher = Session["codigoVoucher"].ToString(); //Traemos el codigo de voucher cargado en la session
                //Voucher voucher = new Voucher();
                //voucher.IdCliente = cliente.Id;
                //voucher.FechaCanje = DateTime.Now;
                //voucher.IdArticulo = aca tenemos que hacer viajar el codigo del articulo
                //voucher.CodigoVoucher = codigoVoucher;
                //voucherNegocio.modificar(voucher);

            //chkAceptar = true para dejar participar

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