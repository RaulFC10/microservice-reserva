using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reservas.Domain.Model.ReservaAnulados;
using System.Diagnostics.CodeAnalysis;

namespace Reservas.Infraestructure.EF.Config.WriteConfig
{
    [ExcludeFromCodeCoverage]
    public class ReservaAnuladoWriteConfig : IEntityTypeConfiguration<ReservaAnulado>
    {
        public void Configure(EntityTypeBuilder<ReservaAnulado> builder)
        {
            builder.ToTable("ReservaAnulado");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fecha)
                .HasColumnName("fecha")
               .HasColumnType("date");

   
            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion")
                .HasMaxLength(100);

            builder.Ignore("_domainEvents");
            builder.Ignore(x => x.DomainEvents);

        }
    }
}
