using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    [ExcludeFromCodeCoverage]
    public class PagoReadConfig : IEntityTypeConfiguration<PagoReadModel>
    {
        public void Configure(EntityTypeBuilder<PagoReadModel> builder)
        {
            builder.ToTable("Pago");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("datetime");

            builder.Property(x => x.Importe)
                .HasColumnName("importe")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);


            builder.Property(x => x.ImportePagado)
                .HasColumnName("importePagado")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.HasOne(d => d.Reserva)
                .WithMany(p => p.Pago);


        }
    }
}
