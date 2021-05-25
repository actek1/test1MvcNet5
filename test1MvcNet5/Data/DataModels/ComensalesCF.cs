using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test1MvcNet5.Data.DataModels
{
    public class ComensalesCF
    {
        public int ComensalesId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public char Sexo { get; set; }
        public DateTime FeechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
