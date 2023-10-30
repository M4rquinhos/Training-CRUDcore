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
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
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

        public IActionResult Editar(int idContacto)
        {
            var contacto = _contactoDatos.Obtener(idContacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel contacto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var respuesta = _contactoDatos.Editar(contacto);
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

        public IActionResult Eliminar(int idContacto)
        {
            var contacto = _contactoDatos.Obtener(idContacto);
            return View(contacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto)
        {
            var respuesta = _contactoDatos.Eliminar(contacto.Id);

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
