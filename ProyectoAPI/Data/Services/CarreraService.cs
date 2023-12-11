// CarreraService.cs

using ProyectoAPI.Data;
using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System;
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

        public void AddCarrera(CarreraVM carrera)
        {
            var _carrera = new Carrera()
            {
                Nombre = carrera.Nombre
            };
            _context.Carrera.Add(_carrera);
            _context.SaveChanges();
        }

        public List<Carrera> GetAllCarreras() => _context.Carrera.ToList();

        public Carrera GetCarreraById(int carreraID)
        {
            var carrera = _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraID);

            if (carrera == null)
            {
                throw new InvalidOperationException($"No se encontró la carrera con ID {carreraID}");
            }

            return carrera;
        }

        public Carrera UpdateCarreraById(int carreraid, CarreraVM carrera)
        {
            var _carrera = _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraid);

            if (_carrera != null)
            {
                _carrera.Nombre = carrera.Nombre;
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró la carrera con ID {carreraid}");
            }

            return _carrera;
        }

        public void DeleteCarreraById(int carreraid)
        {
            var _carrera = _context.Carrera.FirstOrDefault(n => n.IDCarrera == carreraid);

            if (_carrera != null)
            {
                _context.Carrera.Remove(_carrera);
                _context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException($"No se encontró la carrera con ID {carreraid}");
            }
        }
    }
}
