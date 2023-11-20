using System.Web;
using System;



namespace APIRestful_Clientes.Controllers
{
    public class Logger
    {
        private string logPath;


        // Creo el constructor de la clase que chequea si el directorio de logs existe
        public Logger()
        {
            // Busco el directorio de ejecucion del programa
            logPath = "C:\\logs\\";

            // Chequeo si el directorio de logs existe
            if (!System.IO.Directory.Exists(logPath))
            {
                // Si no existe, lo creo
                System.IO.Directory.CreateDirectory(logPath);
            }
        }

        public void Logs(string message)
        {
            // Creo el archivo de logs
            string logFile = System.IO.Path.Combine(logPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}.log");
            // Escribo el mensaje en el archivo de logs
            System.IO.File.AppendAllText(logFile, message);
        }
    }
}
