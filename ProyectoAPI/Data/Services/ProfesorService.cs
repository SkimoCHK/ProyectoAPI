using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAPI.Data.Services
{
    public class ProfesorService
    {
        private AppDbContext _context;

        public ProfesorService(AppDbContext context)
        {
            _context = context;
        }

        //Antiguo metodo que obtiene los nombres de los profes pero sin el nombre de la carrera
        //public List<Profesor> GetAllProfesores() => _context.Profesores.ToList();

        public string GetCarreraNombreById(int carreraId)
        {
            var carrera = _context.Carrera.FirstOrDefault(c => c.IDCarrera == carreraId);
            return carrera != null ? carrera.Nombre : null;
        }

        public List<ProfesorVM> GetAllProfesores()
        {
            // Obtiene la lista de profesores desde la base de datos
            var profesores = _context.Profesores.ToList();

            // Mapea la lista de Profesor a ProfesorVM
            var profesoresVM = profesores.Select(profe => new ProfesorVM
            {
                Nombre = profe.Nombre,
                ApePa = profe.ApePa,
                ApeMa = profe.ApeMa,
                Email = profe.Email,
                Contrasenia = profe.Contrasenia,
                CarreraId = profe.CarreraId,
                CarreraNombre = GetCarreraNombreById(profe.CarreraId)
            }).ToList();

            return profesoresVM;
        }

        //Antiguo metodo que obtiene los nombres de los profes pero sin el nombre de la carrera
        //public Profesor GetProfesorById(int profesorId) => _context.Profesores.FirstOrDefault(n => n.Id == profesorId);
        public ProfesorVM GetProfesorById(int profesorId)
        {
            var profesor = _context.Profesores.FirstOrDefault(n => n.Id == profesorId);

            if (profesor == null)
            {
                return null; // O puedes manejar el caso en el que no se encuentra el profesor
            }

            var profesorVM = new ProfesorVM
            {
                Nombre = profesor.Nombre,
                ApePa = profesor.ApePa,
                ApeMa = profesor.ApeMa,
                Email = profesor.Email,
                Contrasenia = profesor.Contrasenia,
                CarreraId = profesor.CarreraId,
                CarreraNombre = GetCarreraNombreById(profesor.CarreraId)
            };

            return profesorVM;
        }


        public void AddProfesor(ProfesorVM profe)
        {
            var _profesor = new Profesor()
            {
                Nombre = profe.Nombre,
                ApePa = profe.ApePa,
                ApeMa = profe.ApeMa,
                Email = profe.Email,
                Contrasenia = profe.Contrasenia,
                CarreraId = profe.CarreraId
            };

            _context.Profesores.Add(_profesor);
            _context.SaveChanges();
        }

        public Profesor UpdateProfesorById(int profesorid, ProfesorVM profesor)
        {
            var _profesor = _context.Profesores.FirstOrDefault(n => n.Id == profesorid);
            if (_profesor != null)
            {
                _profesor.Nombre = profesor.Nombre;
                _profesor.ApePa = profesor.ApePa;
                _profesor.ApeMa = profesor.ApeMa;
                _profesor.Email = profesor.Email;
                _profesor.Contrasenia = profesor.Contrasenia;
                _profesor.CarreraId = profesor.CarreraId;

                _context.SaveChanges();
            }
            return _profesor;
        }

        public void DeleteProfesorById(int profesorid)
        {
            var _profesor = _context.Profesores.FirstOrDefault(n => n.Id == profesorid);
            if (_profesor != null)
            {
                _context.Profesores.Remove(_profesor);
                _context.SaveChanges();
            }
        }



    }
}
