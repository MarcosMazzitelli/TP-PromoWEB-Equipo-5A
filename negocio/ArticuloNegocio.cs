using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using datos;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List <Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion as Marca, A.IdCategoria, C.Descripcion as Categoria, A.Precio FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id;");
                datos.ejecutarLectura();

                while (datos.Lector.Read()){
                    Articulo aux = new Articulo();
                    //se castean los Objects que se leen de la base de datos y se asignan a los atributos de la instancia aux por cada vuelta.
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca(); //nueva instancia del objeto Marca dentro de la clase Articulo
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"]; //Asignamos valor. Mar es el alias de la consulta sql
                    aux.Categoria = new Categoria(); //nueva instancia del objeto Categoria dentro de la clase Articulo
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"]; //Asignamos valor. Cat es el alias de la consulta sql
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"]; //Asignamos valor a Id Categoria para poder utilizarlo en el modificar (cboCategoria.SelectedValue)
                    aux.Marca.Id = (int)datos.Lector["IdMarca"]; // Asignamos valor a Id Marca para poder utilizarlo en el modificar (cboMarca.SelectedValue)
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    //Se asigna una instancia de aux a la lista por cada vuelta.
                    lista.Add(aux);
                }
                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {
                //FALTA MOSTRAR EL MENSAJE DE ERROR, aca no existe MessageBox
                throw ex;
            }
        }
        public string buscarNombreArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Nombre FROM Articulos WHERE Id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                   articulo.Nombre = (string)datos.Lector["Nombre"];
                  
                    return articulo.Nombre;
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
