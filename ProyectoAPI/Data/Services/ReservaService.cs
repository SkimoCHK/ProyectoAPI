// ReservaService.cs

using ProyectoAPI.Data.Models;
using ProyectoAPI.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoAPI.Data.Services
{
    public class ReservaService
    {
        private AppDbContext _context;

        public ReservaService(AppDbContext context)
        {
            _context = context;
        }

        public void AddReserva(ReservaVM reserva)
        {
            try
            {
                var _reserva = new Reserva()
                {
                    Fecha = reserva.Fecha,
                    HoraInicio = TimeSpan.Parse(reserva.HoraInicio),
                    HoraFin = TimeSpan.Parse(reserva.HoraFin),
                    ProfesorID = reserva.ProfesorID,
                    InstalacionID = reserva.InstalacionID
                };

                // Resto del código para agregar la reserva y guardar en la base de datos

                _context.Reserva.Add(_reserva);
                _context.SaveChanges();
            }
            catch (FormatException ex)
            {
                throw new InvalidOperationException("Error al procesar la reserva. Asegúrate de que los formatos de fecha y hora son correctos.", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar la reserva.", ex);
            }
        }

        public List<Reserva> GetAllReservas() => _context.Reserva.ToList();

        public Reserva GetReservaById(int reservaID)
        {
            var _reserva = _context.Reserva.FirstOrDefault(n => n.Id == reservaID);

            if (_reserva == null)
            {
                throw new InvalidOperationException($"No se encontró la reserva con ID {reservaID}");
            }

            return _reserva;
        }

        public Reserva UpdateReservaById(int reservaID, ReservaVM reserva)
        {
            var _reserva = _context.Reserva.FirstOrDefault(n => n.Id == reservaID);

            if (_reserva != null)
            {
                try
                {
                    _reserva.Fecha = reserva.Fecha;
                    _reserva.HoraInicio = TimeSpan.Parse(reserva.HoraInicio);
                    _reserva.HoraFin = TimeSpan.Parse(reserva.HoraFin);
                    _reserva.ProfesorID = reserva.ProfesorID;
                    _reserva.InstalacionID = reserva.InstalacionID;
                    _context.SaveChanges();
                }
                catch (FormatException ex)
                {
                    throw new InvalidOperationException("Error al procesar la reserva. Asegúrate de que los formatos de fecha y hora son correctos.", ex);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error al actualizar la reserva.", ex);
                }
            }
            else
            {
                throw new InvalidOperationException($"No se encontró la reserva con ID {reservaID}");
            }

            return _reserva;
        }

        public void DeleteReservaById(int reservaID)
        {
            var _reserva = _context.Reserva.FirstOrDefault(n => n.Id == reservaID);

            if (_reserva != null)
            {
                try
                {
                    _context.Reserva.Remove(_reserva);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Error al eliminar la reserva.", ex);
                }
            }
            else
            {
                throw new InvalidOperationException($"No se encontró la reserva con ID {reservaID}");
            }
        }
    }
}
