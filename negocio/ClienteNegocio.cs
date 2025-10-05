using datos;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class ClienteNegocio
    {
      
        public List<Cliente> listar()
        {
            List<Cliente> listaCliente = new List <Cliente>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido,Email, Direccion, Ciudad, CP FROM Clientes");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Id = (int)datos.Lector["Id"];
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CP = (int)datos.Lector["CP"];
                    listaCliente.Add(cliente);
                }
                return listaCliente;
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

        public Cliente buscarClientePorDni(string dni) 
        {
            List<Cliente> listaClientes = new List<Cliente>();
            listaClientes = listar();
            try {
                foreach (var item in listaClientes)
                {
                    if (item.Documento == dni)
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Cliente buscarClienteDni(string dni)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP FROM Clientes WHERE Documento = @documento");
                datos.setearParametro("@documento", dni);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Documento = (string)datos.Lector["Documento"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Direccion = (string)datos.Lector["Direccion"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                    cliente.CP = (int)datos.Lector["CP"];
                    cliente.Id = (int)datos.Lector["Id"];
                    return cliente;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    
        public int agregarCliente(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
            datos.setearConsulta(@"INSERT INTO Clientes (Documento, Nombre, Apellido, Email, Direccion, Ciudad, CP) output inserted.Id VALUES (@documento, @nombre, @apellido, @email, @direccion, @ciudad, @cp)");// Parametros (@Clave, valor) clave seria el nombre de la columna y valor el lo que tiene el objeto recibido por parametro en cada atributo
                datos.setearParametro("@documento", nuevo.Documento);
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@email", nuevo.Email);
                datos.setearParametro("@direccion", nuevo.Direccion);
                datos.setearParametro("@ciudad", nuevo.Ciudad);
                datos.setearParametro("@cp", nuevo.CP);

                int idCliente = datos.ejecutarEscalar(); 
                return idCliente;
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

        public void modificar (Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update CLIENTES set Documento = @documento, Nombre = @nombre, Apellido = @apellido, Email = @email, Direccion = @direccion, Ciudad = @ciudad, CP = @cp where Id = @id");
                datos.setearParametro("@documento", cliente.Documento);
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@email", cliente.Email);
                datos.setearParametro("@direccion", cliente.Direccion);
                datos.setearParametro("@ciudad", cliente.Ciudad);
                datos.setearParametro("@cp", cliente.CP);
                datos.setearParametro("@id", cliente.Id);
                datos.ejecutarAccion();

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
