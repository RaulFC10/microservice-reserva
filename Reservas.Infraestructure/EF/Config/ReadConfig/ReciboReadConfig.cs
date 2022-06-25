using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    [ExcludeFromCodeCoverage]
    public class ReciboReadConfig : IEntityTypeConfiguration<ReciboReadModel>
    {
        public void Configure(EntityTypeBuilder<ReciboReadModel> builder)
        {
            builder.ToTable("Recibo");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroRecibo)
                .HasColumnName("nroRecibo")
                .HasMaxLength(6);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("datetime");

            builder.Property(x => x.ImporteTotal)
                .HasColumnName("importeTotal")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.ImportePagado)
                .HasColumnName("importePagado")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);


            builder.Property(x => x.Saldo)
                .HasColumnName("saldo")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);
        }
    }
}
