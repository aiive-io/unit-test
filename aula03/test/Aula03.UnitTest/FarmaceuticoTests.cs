using FluentAssertions;
using System;
using Xunit;

namespace Aula03.UnitTest
{
    public class FarmaceuticoTests
    {
        [Fact]
        public void Farmaceutico_Com_DataAdmissao_Nao_Pode_Ser_Contratado()
        {
            var farmaceutico = new Farmaceutico(Guid.NewGuid(), "Teste");

            farmaceutico.Contratar(dataAdmissao: new DateTime(day: 01, month: 01, year: 2021));

            Action act = () => farmaceutico.Contratar(dataAdmissao: new DateTime(day: 01, month: 01, year: 2021));

            act.Should().Throw<ArgumentException>().WithParameterName("DataAdmissao");
        }
    }
}
