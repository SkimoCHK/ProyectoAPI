using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAPI.Data.Services
{
    public class CarreraService
    {
        private AppDbContext _context;
        
        public CarreraService(AppDbContext context)
        {
            _context = context;
        }

        //Método que nos permite agregar una carrera en la bd

        public void AddCarrera(CarreraVM carrera)
        {
            var _carrera = new Carrera()
            {
                Nombre = carrera.Nombre
            };
            _context.Carrera.Add(_carrera);
            _context.SaveChanges();
        }

        //Método que nos permite obtener una lista de todas las carrera en la bd

        public List<Carrera> GetAllCarreras() => _context.Carrera.ToList();

        //Método que nos permite obtener una carrera por id de la bd
        public Carrera GetCarreraById(int carreraID) => _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraID);

        //Método que nos permite editar una carrera en la bd

        public Carrera UpdateCarreraById(int carreraid, CarreraVM carrera)
        {
            var _carrera = _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraid);
            if(_carrera != null) {
               _carrera.Nombre = carrera.Nombre;
                _context.SaveChanges();
            }
            return _carrera;
        }
        public void DeleteCarreraById(int carreraid)
        {
            var _carrera = _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraid);
            if(_carrera != null)
            {
                _context.Carrera.Remove(_carrera);
                _context.SaveChanges();
            }
        }



    }
}
