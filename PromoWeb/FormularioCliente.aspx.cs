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
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = clienteNegocio.listar();
            Cliente cliente = new Cliente();
            foreach (var item in listaClientes)
            {
                if(item.Documento == txtDocumento.Text)
                {
                    txtNombre.Text = item.Nombre;
                    txtApellido.Text = item.Apellido;
                    txtEmail.Text = item.Email;
                    txtDireccion.Text = item.Direccion; 
                    txtCiudad.Text = item.Ciudad;
                    txtCP.Text = item.CP.ToString();
                }
            }

        }

        protected void BtnParticipar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Documento = txtDocumento.Text;
            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Email = txtEmail.Text;
            cliente.Direccion = txtDireccion.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.CP = int.Parse(txtCP.Text);
            //chkAceptar = true para dejar participar

           
            
        }

        protected void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }
    }
}