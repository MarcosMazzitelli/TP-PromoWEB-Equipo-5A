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
            alertWarning1.Visible = false;
            alertWarning2.Visible = false;

            string codigoVoucher = txtVoucher.Text;
            VoucherNegocio negocio = new VoucherNegocio();

            try
            {
                Voucher voucher = negocio.buscarPorCodigo(codigoVoucher);

                if (voucher == null)
                {
                    alertWarning1.Visible = true;
                    return;
                }

                if (voucher.IdCliente != 0)
                {
                    alertWarning2.Visible = true;
                    return;
                }

                Session["codigoVoucher"] = voucher.CodigoVoucher;
                Response.Redirect("Premios.aspx", false);
            }
            catch (Exception ex)
            {
                alertDanger.Visible = true;
                Session.Add("error", ex.ToString());
            }
        }
    }
}