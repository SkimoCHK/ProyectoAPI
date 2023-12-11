using System;

namespace ProyectoAPI.Data.ViewModels
{
    public class ReservaVM
    {

        public DateTime Fecha { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public int ProfesorID { get; set; }
        public int InstalacionID { get; set; }


    }
}
