using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PromoWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtVoucher.Text;
            VoucherNegocio negocio = new VoucherNegocio();

            try
            {
                Voucher voucher = negocio.buscarPorCodigo(codigoVoucher);

                if (voucher == null)
                {
                    Session.Add("error", "El código del voucher ingresado no es válido.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                if (voucher.IdCliente != 0)
                {
                    Session.Add("error", "Este voucher ya fue utilizado.");
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                Session.Add("codigoVoucher", voucher.CodigoVoucher);
                Response.Redirect("Premios.aspx", false);
                return;
            }
            catch (System.Threading.ThreadAbortException ex) { }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}