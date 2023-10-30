using System.Data.SqlClient;

namespace CRUDcore.Datos
{
    public class Conexion
    {
        private string cadena = string.Empty;
        public Conexion()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();

            cadena = builder.GetSection("ConnectionStrings:conexion").Value;
        }

        public string GetCadenaSQL()
        {
            return cadena;
        }

    }
}
