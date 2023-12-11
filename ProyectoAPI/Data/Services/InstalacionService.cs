using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAPI.Data.Services
{
    public class InstalacionService
    {
        private AppDbContext _context;

        public InstalacionService(AppDbContext context)
        {
            _context = context;
        }

       
        public void AddInstalacion(InstalacionVM instalacion)
        {
            var _instalacion = new Instalacion()
            {
                Nombre = instalacion.Nombre,
                Descripcion = instalacion.Descripcion,
                EdificioID = instalacion.EdificioID
            };
            _context.Instalacion.Add(_instalacion);
            _context.SaveChanges();
        }

        
        public List<Instalacion> GetAllInstalaciones() => _context.Instalacion.ToList();

        
        public Instalacion GetInstalacionById(int instalacionID) => _context.Instalacion.FirstOrDefault(n => n.Id == instalacionID);

      
        public Instalacion UpdateInstalacionById(int instalacionID, InstalacionVM instalacion)
        {
            var _instalacion = _context.Instalacion.FirstOrDefault(n => n.Id == instalacionID);
            if (_instalacion != null)
            {
                _instalacion.Nombre = instalacion.Nombre;
                _instalacion.Descripcion = instalacion.Descripcion;
                _instalacion.EdificioID = instalacion.EdificioID;

                _context.SaveChanges();
            }
            return _instalacion;
        }

       
        public void DeleteInstalacionById(int instalacionID)
        {
            var _instalacion = _context.Instalacion.FirstOrDefault(n => n.Id == instalacionID);
            if (_instalacion != null)
            {
                _context.Instalacion.Remove(_instalacion);
                _context.SaveChanges();
            }
        }
    }
}
