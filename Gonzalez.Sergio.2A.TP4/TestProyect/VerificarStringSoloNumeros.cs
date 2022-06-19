using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestProyect
{
    [TestClass]
    public class VerificarStringSoloNumeros
    {
        [DataRow("Hola")]
        [DataRow("123/45")]
        [DataRow("123.45")]
        [DataRow("123-45")]
        [DataRow("123 45678")]
        [DataRow("    ")]
        [DataRow(null)]
        [TestMethod]
        public void VerificarStringSoloNumeros_Error(string cadena)
        {
            bool resultado = Persona.VerificarStringSoloNumeros(cadena);

            Assert.IsFalse(resultado);
        }
        [TestMethod]
        public void VerificarStringSoloNumeros_Correcto()
        {
            bool resultado = Persona.VerificarStringSoloNumeros("12345678");

            Assert.IsTrue(resultado);
        }        
    }
}
