using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InnovacionDocentes.Models;

namespace InnovacionDocentes.Controllers
{
    public class ContenidoesController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Contenidoes
        public ActionResult Index()
        {
            var contenido = db.Contenido.Include(c => c.CatAsignatura).Include(c => c.Tema);
            return View(contenido.ToList());
        }

        // GET: Contenidoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // GET: Contenidoes/Create
        public ActionResult Create()
        {
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion");
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre");
            return View();
        }

        // POST: Contenidoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idContenido,strDescripcion,idTema,idAsignatura")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                db.Contenido.Add(contenido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", contenido.idAsignatura);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", contenido.idTema);
            return View(contenido);
        }

        // GET: Contenidoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", contenido.idAsignatura);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", contenido.idTema);
            return View(contenido);
        }

        // POST: Contenidoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idContenido,strDescripcion,idTema,idAsignatura")] Contenido contenido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contenido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", contenido.idAsignatura);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", contenido.idTema);
            return View(contenido);
        }

        // GET: Contenidoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contenido contenido = db.Contenido.Find(id);
            if (contenido == null)
            {
                return HttpNotFound();
            }
            return View(contenido);
        }

        // POST: Contenidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contenido contenido = db.Contenido.Find(id);
            db.Contenido.Remove(contenido);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
