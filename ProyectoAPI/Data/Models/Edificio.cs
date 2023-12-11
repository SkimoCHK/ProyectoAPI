using System.Collections.Generic;

namespace ProyectoAPI.Data.Models
{
    public class Edificio
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        //Propiedades de navegacion

        public List<Instalacion> Instalaciones { get; set; }
    }
}
