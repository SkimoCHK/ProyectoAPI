using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using System.Linq;
using ProyectoAPI.Data.Models;

namespace ProyectoAPI.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Carrera.Any())
                {
                    context.Carrera.AddRange(new Carrera()
                    {
                        Nombre = "Tecnologías de la Información"
                    },
                    new Carrera()
                    {
                        Nombre = "Mecatronica"
                    });
                    context.SaveChanges();


                    
                }

            }
        }

    }
}
