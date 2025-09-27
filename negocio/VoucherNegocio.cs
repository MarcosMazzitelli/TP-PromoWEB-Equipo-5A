using datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VoucherNegocio
    {
        public Voucher buscarPorCodigo(string codigoVoucher)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT V.CodigoVoucher, V.IdCliente, V.FechaCanje, V.IdArticulo FROM Vouchers V WHERE V.CodigoVoucher = @codigoVoucher");
                datos.setearParametro("@codigoVoucher", codigoVoucher);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Voucher aux = new Voucher();

                    aux.CodigoVoucher = (string)datos.Lector["CodigoVoucher"];
                    aux.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.FechaCanje = (DateTime)datos.Lector["FechaCanje"];
                    aux.IdArticulo = (int)datos.Lector["IdArticulo"];

                    return aux;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
