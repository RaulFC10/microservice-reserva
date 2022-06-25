using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    [ExcludeFromCodeCoverage]
    public class FacturaReadConfig : IEntityTypeConfiguration<FacturaReadModel>
    {
        public void Configure(EntityTypeBuilder<FacturaReadModel> builder)
        {
            builder.ToTable("Factura");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroFactura)
                .HasColumnName("nroFactura")
                .HasMaxLength(6);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("datetime");

            builder.Property(x => x.Importe)
                .HasColumnName("importe")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasOne(d => d.Pago)
                .WithMany(p => p.Factura);

        }
    }
}
