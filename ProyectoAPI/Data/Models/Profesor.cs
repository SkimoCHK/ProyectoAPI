using ProyectoAPI.Data.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAPI.Data.Models
{
    public class Profesor
    {

        public int Id { get; set; }

        public string Nombre { get; set; }

        public string ApePa { get; set; }

        public string ApeMa { get; set; }

        public string Email { get; set; }

        public string Contrasenia { get; set; }

        
        //Propiedades de navegacion

        public int CarreraId { get; set; }

        public Carrera Carrera { get; set; }

        public List<Reserva> Reservas { get; set; }

    }
}
