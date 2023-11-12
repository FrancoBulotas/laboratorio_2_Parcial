using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class UsuarioDAO
    {
        // ES ESTATICA PARA QUE SE UTILICE UNO SOLO DE ESTOS ATRIBUTOS.
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static UsuarioDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=Sispro;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="contrasenia"></param>
        /// <param name="tipoUsuario"></param>
        /// <returns></returns>
        public static bool Guardar(string nombre, string contrasenia, string tipoUsuario)
        {
            try
            {
                command.Parameters.Clear(); // PARA EVITAR INYECCIONES SQL
                connection.Open();
                command.CommandText = $"INSERT INTO usuarios (nombre, contrasenia, tipo_usuario, trabajos_realizados) VALUES (@nombre, @contrasenia, @tipo, @trabajos)";
                command.Parameters.AddWithValue("@nombre", nombre); // PARA EVITAR INYECCIONES SQL
                command.Parameters.AddWithValue("@contrasenia", contrasenia); 
                command.Parameters.AddWithValue("@tipo", tipoUsuario); 
                command.Parameters.AddWithValue("@trabajos", 0); 
                int rows = command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                
                return false;
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> LeerTodo()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            try
            {
                connection.Open();
                command.CommandText = $"SELECT * FROM usuarios";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaUsuarios.Add(new Usuario(Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["contrasenia"].ToString(), reader["tipo_usuario"].ToString(), Convert.ToInt32(reader["trabajos_realizados"])));
                    }
                }

                return listaUsuarios;
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nuevoDato"></param>
        /// <param name="id"></param>
        /// <param name="columna"></param>
        public static void Modificar(string nuevoDato, int id, string columna)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE usuarios SET {columna} = @nuevoDato WHERE id = @id";
                command.Parameters.AddWithValue("@nuevoDato", nuevoDato);
                command.Parameters.AddWithValue("@id", id);
                int rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nuevoNombre"></param>
        /// <param name="id"></param>
        public static void ModificarTrabajos(int id)
        {
            int cant = 1;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE usuarios SET trabajos_realizados += {cant} WHERE id = @id";
                command.Parameters.AddWithValue("@id", id);
                int rows = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public static void Eliminar(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"DELETE FROM usuarios WHERE ID = @id";
                command.Parameters.AddWithValue("@id", id);
                int rows = command.ExecuteNonQuery();   // cantidad de filas afectadas por la consulta
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
