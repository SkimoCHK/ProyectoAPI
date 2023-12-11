using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoAPI.Data.Models
{
    public class Carrera
    {

        public int IDCarrera { get; set; }
        
        public string Nombre { get; set; }

        //Propiedades de navegacion

        public List<Profesor> Profesores { get; set; }

    }
}
