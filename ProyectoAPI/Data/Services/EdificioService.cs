using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAPI.Data.Services
{
    public class EdificioService
    {

        private AppDbContext _context;

        public EdificioService(AppDbContext context)
        {
            _context = context;
        }

        

        public void AddEdificio(EdificioVM edificio)
        {
            var _edificio = new Edificio()
            {
                Nombre = edificio.Nombre,
                Descripcion = edificio.Descripcion
            };
            _context.Edificio.Add(_edificio);
            _context.SaveChanges();
        }

        

        public List<Edificio> GetAllEdificios() => _context.Edificio.ToList();

      
        public Edificio GetEdificioById(int edificioID) => _context.Edificio.FirstOrDefault(n => n.Id == edificioID);

        

        public Edificio UpdateEdificioById(int edificioID, EdificioVM edificio)
        {
            var _edificio = _context.Edificio.FirstOrDefault(n => n.Id == edificioID);
            if (_edificio != null)
            {
                _edificio.Nombre = edificio.Nombre;
                _edificio.Descripcion = edificio.Descripcion;
                _context.SaveChanges();
            }
            return _edificio;
        }
        public void DeleteEdificioById(int edificioID)
        {
            var _edificio = _context.Edificio.FirstOrDefault(n => n.Id == edificioID);
            if (_edificio != null)
            {
                _context.Edificio.Remove(_edificio);
                _context.SaveChanges();
            }
        }

    }
}
