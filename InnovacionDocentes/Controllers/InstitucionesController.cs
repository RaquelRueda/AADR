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
    public class InstitucionesController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Instituciones

            [Authorize (Users = "israelparedesdiaz29@gmail.com")]
        public ActionResult Index()
        {
            var instituciones = db.Instituciones.Include(i => i.CatEstado).Include(i => i.CatMunicipio);
            return View(instituciones.ToList());
        }

        // GET: Instituciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.Instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            return View(instituciones);
        }

        // GET: Instituciones/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.CatEstado, "idEstado", "strDescripcion");
            ViewBag.idMunicipio = new SelectList(db.CatMunicipio, "idMunicipio", "strDescripcion");
            return View();
        }

        // POST: Instituciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idInstintucion,strNombre,strClave,idEstado,idMunicipio")] Instituciones instituciones)
        {
            if (ModelState.IsValid)
            {
                db.Instituciones.Add(instituciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.CatEstado, "idEstado", "strDescripcion", instituciones.idEstado);
            ViewBag.idMunicipio = new SelectList(db.CatMunicipio, "idMunicipio", "strDescripcion", instituciones.idMunicipio);
            return View(instituciones);
        }

        // GET: Instituciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.Instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.CatEstado, "idEstado", "strDescripcion", instituciones.idEstado);
            ViewBag.idMunicipio = new SelectList(db.CatMunicipio, "idMunicipio", "strDescripcion", instituciones.idMunicipio);
            return View(instituciones);
        }

        // POST: Instituciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idInstintucion,strNombre,strClave,idEstado,idMunicipio")] Instituciones instituciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instituciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.CatEstado, "idEstado", "strDescripcion", instituciones.idEstado);
            ViewBag.idMunicipio = new SelectList(db.CatMunicipio, "idMunicipio", "strDescripcion", instituciones.idMunicipio);
            return View(instituciones);
        }

        // GET: Instituciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Instituciones instituciones = db.Instituciones.Find(id);
            if (instituciones == null)
            {
                return HttpNotFound();
            }
            return View(instituciones);
        }

        // POST: Instituciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Instituciones instituciones = db.Instituciones.Find(id);
            db.Instituciones.Remove(instituciones);
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
