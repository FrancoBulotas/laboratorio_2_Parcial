using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Biblioteca
{
    public class Archivo 
    {
        Administracion administracion;

        public Archivo(Administracion administracion)
        {
            this.administracion = administracion;
        }

        public void SerializarXML<T>(T objeto, string nombreArchivo)
        {
            using (StreamWriter streamWriter = new StreamWriter($"xml\\{nombreArchivo}.xml"))
            {
                try
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(streamWriter, objeto);
                }
                catch (Exception error)
                {
                    CargarErrorLog(administracion.MensajeError(error));
                }
            }
        }

        /// <summary>
        /// Se encarga de cargar el detalle del error al archivo errores.log
        /// </summary>
        /// <param name="error"></param>
        public void CargarErrorLog(string error)
        {
            using (StreamWriter sw = new StreamWriter("log\\errores.log", true))
            {
                sw.WriteLine(error);
            }
            administracion.DispararEventoLogError(error);
        }

        /// <summary>
        /// Se encarga de serializar un Dict de configuraciones en un archivo json.
        /// </summary>
        /// <param name="config"></param>
        public static void SerializarJSONConfig(Dictionary<string, string> config)
        {
            string configJSON = JsonConvert.SerializeObject(config);

            File.WriteAllText("config\\config.json", configJSON);
        }

        /// <summary>
        /// Se encarga de deserializar el json de la configuracion.
        /// </summary>
        /// <returns>Retorna un dict con claves: FondoApp, FondoLogin, Icono. Donde su valor es la ruta relativa de la imagen.</returns>
        public static Dictionary<string, string> DeserializarJSONConfig()
        {
            string configJSON = File.ReadAllText("config\\config.json");

            Dictionary<string, string> config = JsonConvert.DeserializeObject<Dictionary<string, string>>(configJSON);

            return config;
        }
    }
}
