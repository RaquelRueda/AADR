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
    [Authorize(Users = "raquel.marlen.99@gmail.com")]
    public class TemasController : Controller
    {
        private innovaciontibdEntities1 db = new innovaciontibdEntities1();

        // GET: Temas
        public ActionResult Index()
        {
            var tema = db.Tema.Include(t => t.Aprendizaje).Include(t => t.CatJerarquizacion).Include(t => t.Dosificacion);
            return View(tema.ToList());
        }

        // GET: Temas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // GET: Temas/Create
        public ActionResult Create()
        {
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion");
            ViewBag.idCatJeraquizacion = new SelectList(db.CatJerarquizacion, "idJerarquizacion", "strDescripcion");
            ViewBag.idDosificacion = new SelectList(db.Dosificacion, "idDosificacion", "idDosificacion");
            return View();
        }

        // POST: Temas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTema,strNombre,strDescripcion,idCatJeraquizacion,idDosificacion,idAprendizaje")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Tema.Add(tema);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", tema.idAprendizaje);
            ViewBag.idCatJeraquizacion = new SelectList(db.CatJerarquizacion, "idJerarquizacion", "strDescripcion", tema.idCatJeraquizacion);
            ViewBag.idDosificacion = new SelectList(db.Dosificacion, "idDosificacion", "idDosificacion", tema.idDosificacion);
            return View(tema);
        }

        // GET: Temas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", tema.idAprendizaje);
            ViewBag.idCatJeraquizacion = new SelectList(db.CatJerarquizacion, "idJerarquizacion", "strDescripcion", tema.idCatJeraquizacion);
            ViewBag.idDosificacion = new SelectList(db.Dosificacion, "idDosificacion", "idDosificacion", tema.idDosificacion);
            return View(tema);
        }

        // POST: Temas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTema,strNombre,strDescripcion,idCatJeraquizacion,idDosificacion,idAprendizaje")] Tema tema)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tema).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", tema.idAprendizaje);
            ViewBag.idCatJeraquizacion = new SelectList(db.CatJerarquizacion, "idJerarquizacion", "strDescripcion", tema.idCatJeraquizacion);
            ViewBag.idDosificacion = new SelectList(db.Dosificacion, "idDosificacion", "idDosificacion", tema.idDosificacion);
            return View(tema);
        }

        // GET: Temas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tema tema = db.Tema.Find(id);
            if (tema == null)
            {
                return HttpNotFound();
            }
            return View(tema);
        }

        // POST: Temas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tema tema = db.Tema.Find(id);
            db.Tema.Remove(tema);
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
