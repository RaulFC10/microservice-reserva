using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Reservas;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    [ExcludeFromCodeCoverage]
    public class ReservaWriteConfig : IEntityTypeConfiguration<Reserva>,
        IEntityTypeConfiguration<VueloReserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(x => x.Id);

            var nroReservaConverter = new ValueConverter<NumeroReserva, string>(
                nroReservaValue => nroReservaValue.Value,
                nroReserva => new NumeroReserva(nroReserva)
            );

            builder.Property(x => x.NroReserva)
                .HasConversion(nroReservaConverter)
                .HasColumnName("nroReserva")
                .HasMaxLength(6);

            var costoConverter = new ValueConverter<PrecioValue, decimal>(
                costoValue => costoValue.Value,
                costo => new PrecioValue(costo)
            );

            builder.Property(x => x.FechaVuelo)
               .HasColumnName("fechaVuelo")
               .HasColumnType("date");
               
            

            builder.Property(x => x.Costo)
                .HasConversion(costoConverter)
                .HasColumnName("costo")
                .HasPrecision(12, 2);

            builder.Property(x => x.Fecha)
               .HasColumnName("fecha")
               .HasColumnType("datetime");

            builder.Property(x => x.Hora)
                .HasColumnName("hora")
                .HasColumnType("time");

            builder.Property(x => x.HoraLimite)
                .HasColumnName("horaLimite")
                .HasColumnType("time");

            builder.Property(x => x.Estado)
                .HasColumnName("estado")
                .HasColumnType("char");

            builder.Property(x => x.Activo)
                .HasColumnName("activo")
                .HasColumnType("bit");

            builder.HasMany(typeof(VueloReserva), "_vueloReserva");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
            builder.Ignore(x => x.VueloReserva);
        }

        public void Configure(EntityTypeBuilder<VueloReserva> builder)
        {
            builder.ToTable("VueloReserva");
            builder.HasKey(x => x.Id);

            var costoConverter = new ValueConverter<PrecioValue, decimal>(
                costoValue => costoValue.Value,
                costo => new PrecioValue(costo)
            );

            builder.Property(x => x.Costo)
                .HasConversion(costoConverter)
                .HasColumnName("costo")
                .HasPrecision(12, 2);


            builder.Property(x => x.Activo)
                .HasColumnName("activo")
                .HasColumnType("bit");

            builder.Property(x => x.IdPasajero)
                .HasColumnName("idPasajero")
                .HasColumnType("uniqueidentifier");

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);
        }
    }
}
