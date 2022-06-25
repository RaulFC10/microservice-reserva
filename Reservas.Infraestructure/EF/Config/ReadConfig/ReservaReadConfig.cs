using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Infraestructure.EF.ReadModel;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.ReadConfig
{
    [ExcludeFromCodeCoverage]
    public class ReservaReadConfig : IEntityTypeConfiguration<ReservaReadModel>,
        IEntityTypeConfiguration<VueloReservaReadModel>
    {
        public void Configure(EntityTypeBuilder<ReservaReadModel> builder)
        {
            builder.ToTable("Reserva");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NroReserva)
                .HasColumnName("nroReserva")
                .HasMaxLength(6);

            builder.Property(x => x.FechaVuelo)
                .HasColumnName("fechaVuelo")
                .HasColumnType("date");

            builder.Property(x => x.Costo)
                .HasColumnName("costo")
                .HasColumnType("decimal")
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

            builder.HasMany(x => x.VueloReserva)
                .WithOne(x => x.Reserva);
        }

        public void Configure(EntityTypeBuilder<VueloReservaReadModel> builder)
        {
            builder.ToTable("VueloReserva");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Costo)
                .HasColumnName("costo")
                .HasColumnType("decimal")
                .HasPrecision(12, 2);

            builder.Property(x => x.Activo)
                .HasColumnName("activo")
                .HasColumnType("bit");


            builder.Property(x => x.IdPasajero)
                .HasColumnName("idPasajero")
                .HasColumnType("uniqueidentifier");
        }
    }
}
