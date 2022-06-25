using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.Model.Reservas.ValueObjects;
using Reservas.Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    [ExcludeFromCodeCoverage]
    public class ReciboWriteConfig : IEntityTypeConfiguration<Recibo>
    {
        public void Configure(EntityTypeBuilder<Recibo> builder)
        {
            builder.ToTable("Recibo");
            builder.HasKey(x => x.Id);


            var nroReciboConverter = new ValueConverter<NumeroReserva, string>(
                nroReciboValue => nroReciboValue.Value,
                nroRecibo => new NumeroReserva(nroRecibo)
            );

            builder.Property(x => x.NroRecibo)
                .HasConversion(nroReciboConverter)
                .HasColumnName("nroRecibo")
                .HasMaxLength(6);


            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("datetime");


            var importeTotalConverter = new ValueConverter<PrecioValue, decimal>(
                importeTotalValue => importeTotalValue.Value,
                importeTotal => new PrecioValue(importeTotal)
            );

            builder.Property(x => x.ImporteTotal)
                .HasConversion(importeTotalConverter)
                .HasColumnName("importeTotal")
                .HasPrecision(12, 2);


            var importePagadoConverter = new ValueConverter<PrecioValue, decimal>(
                importeTotalValue => importeTotalValue.Value,
                importeTotal => new PrecioValue(importeTotal)
            );

            builder.Property(x => x.ImportePagado)
                .HasConversion(importePagadoConverter)
                .HasColumnName("importePagado")
                .HasPrecision(12, 2);



            var saldoConverter = new ValueConverter<PrecioValue, decimal>(
                saldoValue => saldoValue.Value,
                saldo => new PrecioValue(saldo)
            );

            builder.Property(x => x.Saldo)
                .HasConversion(saldoConverter)
                .HasColumnName("saldo")
                .HasPrecision(12, 2);
        }
    }
}
