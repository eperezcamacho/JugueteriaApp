using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLogic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.Nombre).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Descripcion).HasMaxLength(100);
            builder.Property(p => p.RestriccionEdad);
            builder.Property(p => p.Compania).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Precio).HasColumnType("Decimal(18,2)");
        }
    }
}
