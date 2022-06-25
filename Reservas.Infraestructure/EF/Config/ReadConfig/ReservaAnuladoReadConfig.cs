using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    [ExcludeFromCodeCoverage]
    public class ReservaAnuladoReadConfig : IEntityTypeConfiguration<ReservaAnuladoReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservaAnuladoReadModel> builder)
        {
            builder.ToTable("ReservaAnulado");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("date");

            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(100);

            builder.HasOne(d => d.Reserva)
                .WithMany(p => p.Anulacion);


        }
    }
}
