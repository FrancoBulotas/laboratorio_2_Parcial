using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class StockDAO
    {
        static string connectionString;
        static SqlCommand command;
        static SqlConnection connection;

        static StockDAO()
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
        /// <returns></returns>
        public static Dictionary<string, int> Leer() 
        {
            Dictionary<string, int> stockDisponible = new Dictionary<string, int>();

            try
            {
                command.CommandText = $"SELECT * FROM stock";

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        stockDisponible["Papel"] = Convert.ToInt32(reader["papel"]);
                        stockDisponible["Tinta"] = Convert.ToInt32(reader["tinta"]);
                        stockDisponible["Troquel"] = Convert.ToInt32(reader["troquel"]);
                        stockDisponible["Encuadernacion"] = Convert.ToInt32(reader["encuadernacion"]);
                    }
                }

                return stockDisponible;
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
        /// <param name="cant"></param>
        /// <param name="columna"></param>
        public static Dictionary<string, int> Modificar(int papelIngresado, int tintaIngresada, int troquelIngresado, int encuIngresado)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"UPDATE stock SET papel += @papelIngresado, tinta += @tintaIngresada, troquel += @troquelIngresado, encuadernacion += @encuIngresado";
                command.Parameters.AddWithValue("@papelIngresado", papelIngresado);
                command.Parameters.AddWithValue("@tintaIngresada", tintaIngresada);
                command.Parameters.AddWithValue("@troquelIngresado", troquelIngresado);
                command.Parameters.AddWithValue("@encuIngresado", encuIngresado);
                int rows = command.ExecuteNonQuery();
                return Leer();
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
    }
}
