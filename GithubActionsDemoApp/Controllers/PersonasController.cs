using GithubActionsDemoApp.Entidades;
using GithubActionsDemoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GithubActionsDemoApp.Controllers
{
    public class PersonasController : Controller
    {
        private readonly ApplicationDbContext context;

        public PersonasController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var personas = await context.Personas.ToListAsync();
            var modelo = new PersonasIndex()
            {
                //Personas = personas
            };
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            context.Add(persona);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona is null)
            {
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return View(persona);
            }

            context.Update(persona);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int id)
        {
            var persona = await context.Personas.FirstOrDefaultAsync(x => x.Id == id);

            if (persona is null)
            {
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarPersona(int id)
        {
            await context.Personas.Where(x => x.Id == id).ExecuteDeleteAsync();
            return RedirectToAction("Index");
        }
    }
}
