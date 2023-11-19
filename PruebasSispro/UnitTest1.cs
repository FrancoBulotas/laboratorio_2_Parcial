using Biblioteca;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ObtenerIndiceListaUsuarios_AlNoEncontrarElUsuario_DeberiaRetornarMenosUno()
        {
            // Arrange
            int resultadoEsperado = -1;
            int id = 50;
            Administracion administracion = new Administracion();

            // Act
            int resultadoActual = administracion.ObtenerIndiceListaUsuarios(id);

            // Assert

            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void ValidarUsuarioRegistro_AlNoEncontrarError_DeberiaRetornarLlaveErrorVacia()
        {
            // Arrange
            Dictionary<string, string> resultadoEsperado = new Dictionary<string, string>
            {
                { "Error", "" }
            };
            Administracion administracion = new Administracion();

            string nombre = "pepe";
            string contra = "12";
            string repContra = "12";
            string tipoUsuario = "operario";
            // Act
            Dictionary<string, string> resultadoActual = administracion.ValidarUsuarioRegistro(nombre, contra, repContra, tipoUsuario);

            // Assert
            Assert.AreEqual(resultadoEsperado["Error"], resultadoActual["Error"]);
        }

        [TestMethod]
        public void 
        
    }
}