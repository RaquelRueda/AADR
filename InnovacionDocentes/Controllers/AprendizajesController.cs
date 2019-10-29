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
    public class AprendizajesController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Aprendizajes
        public ActionResult Index()
        {
            return View(db.Aprendizaje.ToList());
        }

        // GET: Aprendizajes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendizaje aprendizaje = db.Aprendizaje.Find(id);
            if (aprendizaje == null)
            {
                return HttpNotFound();
            }
            return View(aprendizaje);
        }

        // GET: Aprendizajes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aprendizajes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idAprendizaje,strDescripcion")] Aprendizaje aprendizaje)
        {
            if (ModelState.IsValid)
            {
                db.Aprendizaje.Add(aprendizaje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aprendizaje);
        }

        // GET: Aprendizajes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendizaje aprendizaje = db.Aprendizaje.Find(id);
            if (aprendizaje == null)
            {
                return HttpNotFound();
            }
            return View(aprendizaje);
        }

        // POST: Aprendizajes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idAprendizaje,strDescripcion")] Aprendizaje aprendizaje)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aprendizaje).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aprendizaje);
        }

        // GET: Aprendizajes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aprendizaje aprendizaje = db.Aprendizaje.Find(id);
            if (aprendizaje == null)
            {
                return HttpNotFound();
            }
            return View(aprendizaje);
        }

        // POST: Aprendizajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aprendizaje aprendizaje = db.Aprendizaje.Find(id);
            db.Aprendizaje.Remove(aprendizaje);
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
