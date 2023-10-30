using Microsoft.AspNetCore.Mvc;
using CRUDcore.Datos;
using CRUDcore.Models;

namespace CRUDcore.Controllers
{
    public class ContactoController : Controller
    {
        ContactoDatos _contactoDatos = new ContactoDatos();

        public IActionResult Listar()
        {
            var lista = _contactoDatos.Listar();
            return View(lista);
        }

        //Solo muestra la vista
        public IActionResult Guardar()
        {
            return View();
        }

        [HttpPost]
        //Guarda el objeto en la bd
        public IActionResult Guardar(ContactoModel contacto)
        {
            var respuesta = _contactoDatos.Guardar(contacto);
            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {

                return View();
            }
        }
    }
}
