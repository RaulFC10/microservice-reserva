using Reservas.Infraestructure.EF.ReadModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Reservas.Test.Infraestructure.ReadModel
{
    public class ReservaReadModel_Tests
    {
        [Fact]
        public void ReservaReadModel_CheckPropertiesValid()
        {
            var idTest = Guid.NewGuid();
            var nroReservaTest = "R-0001";
            var costoTest = 500;
            var fechaTest = DateTime.Now;
            var fechaVueloTest = DateTime.Now;
            var horaTest = TimeSpan.Parse("10:00");
            var horaLimiteTest = TimeSpan.Parse("10:30");
            var estadoTest = 'R';
            var activoTest = true;
            var idVueloTest = Guid.Empty;



            var obj = new ReservaReadModel();
            Assert.Equal(Guid.Empty, obj.Id);
            Assert.Null(obj.NroReserva);
            Assert.Equal(0,obj.Costo);
            Assert.NotEqual(DateTime.Now, obj.Fecha);
            Assert.NotEqual(DateTime.Now, obj.FechaVuelo);
            Assert.NotEqual(TimeSpan.Parse("10:00"), obj.Hora);
            Assert.NotEqual(TimeSpan.Parse("10:30"), obj.HoraLimite);
            Assert.NotEqual('R', obj.Estado);
            Assert.False(obj.Activo);
            Assert.Equal(Guid.Empty,obj.IdVuelo);



            obj.Id = idTest;
            obj.NroReserva = nroReservaTest;
            obj.Costo = costoTest;
            obj.Fecha = fechaTest;
            obj.FechaVuelo = fechaVueloTest;
            obj.Estado = estadoTest;
            obj.Activo = activoTest;
            obj.Hora = horaTest;
            obj.HoraLimite = horaLimiteTest;
            obj.IdVuelo = idVueloTest;




            Assert.Equal(idTest, obj.Id);
            Assert.Equal(nroReservaTest, obj.NroReserva);
            Assert.Equal(costoTest, obj.Costo);
            Assert.Equal(fechaTest, obj.Fecha);
            Assert.Equal(fechaVueloTest, obj.FechaVuelo);
            Assert.Equal(estadoTest, obj.Estado);
            Assert.Equal(activoTest, obj.Activo);
            Assert.Equal(horaTest, obj.Hora);
            Assert.Equal(horaLimiteTest, obj.HoraLimite);
            Assert.Equal(idVueloTest, obj.IdVuelo);
        }
    }
}
