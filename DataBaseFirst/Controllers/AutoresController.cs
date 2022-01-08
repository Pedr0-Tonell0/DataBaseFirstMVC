using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataBaseFirst.Models;
namespace DataBaseFirst.Controllers
{
    public class AutoresController : Controller
    {
        BibliotecaOKEntities db = new BibliotecaOKEntities();

        [HttpGet]
        public ActionResult Index()
        {
            var lista = from a in db.Autores
                        select a;
            return View("Index", lista.ToList());
        }

        //metodo get, que envie un objeto autor para que lo complete el usuario
        [HttpGet]
        public ActionResult Create()
        {
            //clase viewBag sirve para compartir informacion entre controller y view
            ViewBag.IdPais = new SelectList(db.Paises, "ID", "Nombre");
            ViewBag.Fecha = DateTime.Now.ToShortDateString();
            //si quiero setear alguna propiedad por default
            Autore autor = new Autore();
            autor.Apellido = "(Ingrese aqui el apellido)";
            return View("Create", autor);
        }

        //persiste en la db
        [HttpPost]
        public ActionResult Create(Autore autor)
        {
            db.Autores.Add(autor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TraerxID(int id)
        {
            var autor = db.Autores.Find(id);
            if(autor == null)
            {
                autor.Apellido = "Autor no encontrado";
            }
            return View("Detalle", autor);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var autor = db.Autores.Find(id);
            if (autor == null)
            {
                autor.Apellido = "Autor no encontrado";
            }
            ViewBag.IdPais = new SelectList(db.Paises, "ID", "Nombre");
            return View("Edit", autor);
        }

        //persiste en la db
        [HttpPost]
        public ActionResult Edit(Autore autor)
        {
            db.Entry(autor).State = EntityState.Modified;
            db.SaveChanges();
            //db.ProcModiAutor(autor.ID, autor.Apellido, autor.Nombre, autor.FechaNacimiento, autor.IdPais);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var autor = db.Autores.Find(id);
            if (autor == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
            ViewBag.Autor = autor.Apellido + " " + autor.Nombre;
            return View("Delete", autor);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Borrar(int? id)
        {
            var autor = db.Autores.Find(id);
            db.Autores.Remove(autor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}