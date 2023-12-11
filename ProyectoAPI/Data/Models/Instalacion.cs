using System.Collections.Generic;

namespace ProyectoAPI.Data.Models
{
    public class Instalacion
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Propiedades de navegacion

        public int EdificioID { get; set; }
        public Edificio edificio { get; set; }

        public List<Reserva> Reservas { get; set; }
    }
}
