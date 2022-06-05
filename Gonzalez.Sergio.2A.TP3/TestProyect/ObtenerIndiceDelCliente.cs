using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace TestProyect
{
    [TestClass]
    public class ObtenerIndiceDelCliente
    {

        List<Cliente> l1 = new List<Cliente>();
        Cliente c1 = new Cliente("Sergio", "Gonzalez", "12345678", ETipo.Premium);
        Cliente c2 = new Cliente("Alan", "Gomez", "23456789", ETipo.NoPremium);


        [TestMethod]
        public void ObtenerIndiceDelCliente_CuandoClienteEsNull_DeberiaRetornarMenos1()
        {
            int expected = -1;
            l1.Add(c1);
            l1.Add(c2);

            int resultado = Cliente.ObtenerIndiceDelCliente(null, l1);

            Assert.AreEqual(expected, resultado);
        }
        [TestMethod]
        public void ObtenerIndiceDelCliente_CuandoListaEsNull_DeberiaRetornarMenos1()
        {
            int expected = -1;

            int resultado = Cliente.ObtenerIndiceDelCliente(c1, null);

            Assert.AreEqual(expected, resultado);
        }
        [TestMethod]
        public void ObtenerIndiceDelCliente_CuandoClienteNoEstaEnLaLista_DeberiaRetornarMenos1()
        {
            int expected = -1;
            l1.Add(c1);
            l1.Add(c2);
            Cliente c3 = new Cliente("Jose", "Juarez", "98765432", ETipo.NoPremium);

            int resultado = Cliente.ObtenerIndiceDelCliente(c3, l1);

            Assert.AreEqual(expected, resultado);
        }
        [TestMethod]
        public void ObtenerIndiceDelCliente_CuandoListaEstaVacia_DeberiaRetornarMenos1()
        {
            int expected = -1;
            Cliente c3 = new Cliente("Jose", "Juarez", "98765432", ETipo.NoPremium);

            int resultado = Cliente.ObtenerIndiceDelCliente(c3, l1);

            Assert.AreEqual(expected, resultado);
        }
        [TestMethod]
        public void ObtenerIndiceDelCliente_CuandoClienteSiEstaEnLaLista_DeberiaRetornarSuIndice()
        {
            int expected = 0;
            l1.Add(c1);
            l1.Add(c2);

            int resultado = Cliente.ObtenerIndiceDelCliente(c1, l1);

            Assert.AreEqual(expected, resultado);
        }

    }
}
