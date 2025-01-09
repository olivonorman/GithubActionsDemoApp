using GithubActionsDemoApp.Controllers;
using GithubActionsDemoApp.Entidades;
using GithubActionsDemoApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pruebas
{
    [TestClass]
    public class PersonasControllerTests: BasePruebas
    {
        [TestMethod]
        public async Task Index_RetornaDosPersonas()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);

            contexto.Personas.Add(new Persona() { Nombre = "Nombre 1" });
            contexto.Personas.Add(new Persona() { Nombre = "Nombre 2" });
            await contexto.SaveChangesAsync();

            var contexto2 = ConstruirContext(nombreBD);

            // Prueba
            var controller = new PersonasController(contexto2);
            var respuesta = await controller.Index();

            // Verificación

            var viewResult = respuesta as ViewResult;
            var modelo = (PersonasIndex)viewResult!.Model!;

            Assert.AreEqual(2, modelo.Personas.Count());
        }

        [TestMethod]
        public async Task Index_RetornaVacio_CuandoNoHayPersonas()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContext(nombreBD);

            // Prueba
            var controller = new PersonasController(contexto);
            var respuesta = await controller.Index();

            // Verificación

            var viewResult = respuesta as ViewResult;
            var modelo = (PersonasIndex)viewResult!.Model!;

            Assert.AreEqual(0, modelo.Personas.Count());
        }
    }
}
