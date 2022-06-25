using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.Domain.Model.Pagos;
using Reservas.Domain.ValueObjects;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    [ExcludeFromCodeCoverage]
    public class PagoWriteConfig : IEntityTypeConfiguration<Pago>
    {
        public void Configure(EntityTypeBuilder<Pago> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(x => x.Id);

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


            var importePagadoConverter = new ValueConverter<PrecioValue, decimal>(
                importePagadoValue => importePagadoValue.Value,
                importePagado => new PrecioValue(importePagado)
            );

            builder.Property(x => x.ImportePagado)
                .HasConversion(importePagadoConverter)
                .HasColumnName("importePagado")
                .HasPrecision(12, 2);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);

        }
    }
}
