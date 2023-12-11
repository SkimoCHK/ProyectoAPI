using System;

namespace ProyectoAPI.Data.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; } 
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        
        public int ProfesorID { get; set; }
        public int InstalacionID { get; set; }

        public Profesor profesor { get; set; }
        public Instalacion instalacion { get; set; }

     


    }
}
