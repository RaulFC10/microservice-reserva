using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    [ExcludeFromCodeCoverage]
    public class FacturaWriteConfig : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(x => x.Id);


            var nroFacturaConverter = new ValueConverter<NumeroReserva, string>(
                nroFacturaValue => nroFacturaValue.Value,
                nroFactura => new NumeroReserva(nroFactura)
            );

            builder.Property(x => x.NroFactura)
                .HasConversion(nroFacturaConverter)
                .HasColumnName("nroFactura")
                .HasMaxLength(6);


            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("datetime");

            var importeConverter = new ValueConverter<PrecioValue, decimal>(
                importeValue => importeValue.Value,
                importe => new PrecioValue(importe)
            );

            builder.Property(x => x.Importe)
                .HasConversion(importeConverter)
                .HasColumnName("importe")
                .HasPrecision(12, 2);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
