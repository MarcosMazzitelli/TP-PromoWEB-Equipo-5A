using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using datos;
using dominio;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> listaImagenes = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT Id, IdArticulo, ImagenUrl FROM IMAGENES;");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen auxImg = new Imagen();
                    //Se castean los objetos leidos de la base de datos al tipo de dato que corresponde utilizar en C# y se asignan a los atributos de la instancia AuxImg por cada vuelta
                    auxImg.Id = (int)datos.Lector["Id"];
                    auxImg.IdArticulo = (int)datos.Lector["IdArticulo"];
                    auxImg.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    listaImagenes.Add(auxImg); //Se asigna una instancia de auxImg a la lista por cada vuelta.

                }
                datos.cerrarConexion();
                return listaImagenes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
