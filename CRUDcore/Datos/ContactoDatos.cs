using CRUDcore.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDcore.Datos
{
    public class ContactoDatos
    {
        public List<ContactoModel> Listar()
        {
            var lista = new List<ContactoModel>();

            var conexion = new Conexion();

            using (var con = new SqlConnection(conexion.GetCadenaSQL()))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("sp_Listar", con);
                comando.CommandType = CommandType.StoredProcedure;
                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new ContactoModel()
                        {
                            Id = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }


        public ContactoModel Obtener(int idContacto)
        {
            var contacto = new ContactoModel();

            var conexion = new Conexion();

            using (var con = new SqlConnection(conexion.GetCadenaSQL()))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("sp_Obtener", con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcontacto", SqlDbType.Int).Value = idContacto;
                using (var dr = comando.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        contacto.Id = Convert.ToInt32(dr["IdContacto"]);
                        contacto.Nombre = dr["Nombre"].ToString();
                        contacto.Telefono = dr["Telefono"].ToString();
                        contacto.Correo = dr["Correo"].ToString();
                    }
                }
            }
            return contacto;
        }


        public bool Guardar(ContactoModel contacto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var con = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand("sp_Guardar", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = contacto.Nombre;
                    comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = contacto.Telefono;
                    comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = contacto.Correo;
                    comando.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Editar(ContactoModel contacto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var con = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand("sp_Editar", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@idcontacto", SqlDbType.Int).Value = contacto.Id;
                    comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = contacto.Nombre;
                    comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = contacto.Telefono;
                    comando.Parameters.Add("@correo", SqlDbType.VarChar).Value = contacto.Correo;
                    comando.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }

        public bool Eliminar(int idContacto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var con = new SqlConnection(conexion.GetCadenaSQL()))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand("sp_Eliminar", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add("@idcontacto", SqlDbType.Int).Value = idContacto;
                    comando.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                respuesta = false;
            }

            return respuesta;
        }
    }
}
