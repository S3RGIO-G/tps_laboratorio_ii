using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestProyect
{
    [TestClass]
    public class VerificarStringSoloLetras
    {
        [DataRow("Gen123ial")]
        [DataRow("Gen/ial")]
        [DataRow("Gen.ial")]
        [DataRow("Gen   ial")]
        [DataRow("Gen-ial")]
        [DataRow("Gen?¡ial")]
        [DataRow("   ")]
        [DataRow(null)]
        [TestMethod]
        public void VerificarStringSoloLetras_Error(string cadena)
        {
            bool resultado = Persona.VerificarStringSoloLetras(cadena);

            Assert.IsFalse(resultado);
        }

        [DataRow("Genial")]
        [DataRow("Agüero")]
        [DataRow("Maní")]
        [DataRow("Ñoqui")]
        [DataRow("è")]
        [TestMethod]
        public void VerificarStringSoloLetras_Correcto(string cadena)
        {
            bool resultado = Persona.VerificarStringSoloLetras(cadena);

            Assert.IsTrue(resultado);
        }
    }
}
