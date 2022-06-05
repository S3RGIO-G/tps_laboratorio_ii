using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using BibliotecaException;

namespace Entidades
{
    public static class Archivo<T> where T : class
    {
        private static string path;

        static Archivo()
        {
            path = @"../../../../Base de datos/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }            
        }
        /// <summary>
        /// Serializa los datos pasados por parametros con el nombre y a el tipo especificado
        /// </summary>
        /// <param name="datos"> Datos a serializar </param>
        /// <param name="nombre"> Nombre que tendra el archivo </param>
        /// <param name="tipo"> Tipo de Archivo al que serializar </param>
        public static void Serializar(T datos, string nombre, EArchivo tipo) 
        {
            switch (tipo)
            {
                case EArchivo.JSON:
                    SerializarJson(datos, nombre);
                    break;
                case EArchivo.XML:
                    SerializarXml(datos, nombre);
                    break;
            }
        }

        /// <summary>
        /// Serializa el dato recibido por parametro a un archivo de tipo JSON con el nombre especificado
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="nombre"></param>
        public static void SerializarJson(T datos, string nombre)
        {
            string rutaDelArchivo = path + $"{nombre}.json";
            try
            {
                File.WriteAllText(rutaDelArchivo, JsonSerializer.Serialize(datos));
            }
            catch (Exception e)
            {
                throw new ErrorGuardarDatosException("ERROR, no se encontró el archivo JSON para guardar los datos", e);
            }
        }

        /// <summary>
        /// Serializa el dato recibido por parametro a un archivo de tipo XML con el nombre especificado
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="nombre"></param>
        public static void SerializarXml(T datos, string nombre)
        {
            string rutaDelArchivo = path + $"{nombre}.xml";
            try
            {
                using(StreamWriter sw = new StreamWriter(rutaDelArchivo))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(sw, datos);
                }
            }
            catch (Exception e)
            {
                throw new ErrorGuardarDatosException("ERROR, no se encontró el archivo XML para guardar los datos", e);
            }
        }

        /// <summary>
        /// Deserializa un archivo dependiendo del tipo que sea y el nombre que tenga
        /// </summary>
        /// <param name="nombre"> Nombre del archivo a Deserializar </param>
        /// <param name="tipo"> El tipo de archivo a Deserializar </param>
        /// <returns></returns>
        public static T Deserializar(string nombre, EArchivo tipo)
        {
            T datos = default;
            string newPath = path + $"{nombre}";
            switch (tipo)
            {
                case EArchivo.JSON:
                    datos = DeserializarJson(newPath);
                    break;
                case EArchivo.XML:
                    datos = DeserializarXml(newPath);
                    break;
            }
            return datos;
        }
        /// <summary>
        /// Deserializa el archivo JSON con el nombre especificado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static T DeserializarJson(string nombre)
        {
            T datosLeidos = default;
            try
            {
                if (Directory.GetFiles(path).Contains(nombre))
                {
                    datosLeidos = JsonSerializer.Deserialize<T>(File.ReadAllText(nombre));
                }
                return datosLeidos;
            }
            catch (Exception e)
            {
                throw new ErrorCargarDatosException("ERROR, no se encontró el archivo JSON para cargar los datos", e);
            }
        }
        /// <summary>
        /// Deserializa un archivo XML con el nombre especificado
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        public static T DeserializarXml(string nombre)
        {
            T datos = default;
            try
            {
                using (StreamReader sw = new StreamReader(nombre))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    datos = (T)xmlSerializer.Deserialize(sw);
                }
                return datos;
            }
            catch (Exception e)
            {
                throw new ErrorCargarDatosException("ERROR, no se encontró el archivo XML para cargar los datos", e);
            }
        }
    }
}
