using System;
using Procesos;
using Xunit;

namespace Pruebas
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2020,7,26, 29)]
        [InlineData(2021, 7, 26, 29)]
        [InlineData(2022, 7, 26, 29)]
        [InlineData(2023, 7, 26, 29)]
        [InlineData(2024, 7, 26, 29)]
        [InlineData(2025, 7, 26, 29)]
        [InlineData(2026, 7, 26, 29)]
        [InlineData(2027, 7, 26, 29)]
        [InlineData(2028, 7, 26, 29)]
        [InlineData(2029, 7, 26, 29)]
        [InlineData(2030, 7, 26, 29)]
        [InlineData(2031, 7, 26, 29)]
        [InlineData(2020, 1, 1, 4)]
        [InlineData(2020, 1, 2, 5)]
        [InlineData(2020, 1, 3, 6)]
        [InlineData(2020, 1, 4, 7)]
        [InlineData(2020, 1, 5, 8)]
        [InlineData(2020, 1, 6, 9)]
        [InlineData(2020, 1, 7, 10)]
        [InlineData(2020, 1, 8, 11)]
        [InlineData(2020, 1, 9, 12)]
        [InlineData(2020, 1, 10, 13)]
        [InlineData(2020, 1, 11, 14)]

        public void Test1(int anio, int mes, int dia, int diaEsperado)
        {
            
            Proceso1 proceso = new Proceso1();

            int Resultado = proceso.calcularFechaDespacho(new DateTime(anio, mes, dia)).Day;
            Assert.True(diaEsperado == Resultado);
        }
    }
}
