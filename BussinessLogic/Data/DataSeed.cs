using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Data
{
    public class DataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JugueteriaDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<JugueteriaDbContext>>()))
            {
                // Look for any board games.
                //if (context.Producto.CountAsync().Result > 0)
                //{
                //    return;   // Data was already seeded
                //}

                context.Producto.Add(new Producto
                {
                    Nombre = "Producto Prueba",
                    Descripcion = "Prueba de producto precargado",
                    RestriccionEdad = 18,
                    Compania = "N/A",
                    Precio = 999
                });

                context.SaveChanges();
            }
        }
    }
}
