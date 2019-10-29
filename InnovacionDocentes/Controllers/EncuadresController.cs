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
    [Authorize(Users ="raquel.marlen.99@gmail.com")]
    public class EncuadresController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Encuadres
        public ActionResult Index()
        {
            var encuadre = db.Encuadre.Include(e => e.CatAsignatura).Include(e => e.CatGrado).Include(e => e.CatTrimestre).Include(e => e.Contenido).Include(e => e.Empleado).Include(e => e.Proposito).Include(e => e.Tema);
            return View(encuadre.ToList());
        }

        // GET: Encuadres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuadre encuadre = db.Encuadre.Find(id);
            if (encuadre == null)
            {
                return HttpNotFound();
            }
            return View(encuadre);
        }

        // GET: Encuadres/Create
        public ActionResult Create()
        {
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion");
            ViewBag.idCatGrado = new SelectList(db.CatGrado, "idGrado", "strDescripcion");
            ViewBag.idTrimestre = new SelectList(db.CatTrimestre, "idTrimestre", "strDescripcion");
            ViewBag.idContenido = new SelectList(db.Contenido, "idContenido", "strDescripcion");
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "strNombre");
            ViewBag.idProposito = new SelectList(db.Proposito, "idProposito", "strDescripcion");
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre");
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion");
            return View();
        }

        // POST: Encuadres/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEncuadre,dteFechaInicio,dteFechaFin,idAsignatura,idCatGrado,idEmpleado,idTrimestre,strDuracion,idTema,idContenido,idProposito,idEvaluacion,idAprendizaje,strInicio,strDesarollo,strFin,strObservacion")] Encuadre encuadre)
        {
            if (ModelState.IsValid)
            {
                db.Encuadre.Add(encuadre);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", encuadre.idAsignatura);
            ViewBag.idCatGrado = new SelectList(db.CatGrado, "idGrado", "strDescripcion", encuadre.idCatGrado);
            ViewBag.idTrimestre = new SelectList(db.CatTrimestre, "idTrimestre", "strDescripcion", encuadre.idTrimestre);
            ViewBag.idContenido = new SelectList(db.Contenido, "idContenido", "strDescripcion", encuadre.idContenido);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "strNombre", encuadre.idEmpleado);
            ViewBag.idProposito = new SelectList(db.Proposito, "idProposito", "strDescripcion", encuadre.idProposito);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", encuadre.idTema);
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", encuadre.idAprendizaje);
            return View(encuadre);
        }

        // GET: Encuadres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuadre encuadre = db.Encuadre.Find(id);
            if (encuadre == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", encuadre.idAsignatura);
            ViewBag.idCatGrado = new SelectList(db.CatGrado, "idGrado", "strDescripcion", encuadre.idCatGrado);
            ViewBag.idTrimestre = new SelectList(db.CatTrimestre, "idTrimestre", "strDescripcion", encuadre.idTrimestre);
            ViewBag.idContenido = new SelectList(db.Contenido, "idContenido", "strDescripcion", encuadre.idContenido);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "strNombre", encuadre.idEmpleado);
            ViewBag.idProposito = new SelectList(db.Proposito, "idProposito", "strDescripcion", encuadre.idProposito);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", encuadre.idTema);
            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", encuadre.idAprendizaje);
            return View(encuadre);
        }

        // POST: Encuadres/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEncuadre,dteFechaInicio,dteFechaFin,idAsignatura,idCatGrado,idEmpleado,idTrimestre,strDuracion,idTema,idContenido,idProposito,idEvaluacion,idAprendizaje,strInicio,strDesarollo,strFin,strObservacion")] Encuadre encuadre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuadre).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idAsignatura = new SelectList(db.CatAsignatura, "idAsignatura", "strDescripcion", encuadre.idAsignatura);
            ViewBag.idCatGrado = new SelectList(db.CatGrado, "idGrado", "strDescripcion", encuadre.idCatGrado);
            ViewBag.idTrimestre = new SelectList(db.CatTrimestre, "idTrimestre", "strDescripcion", encuadre.idTrimestre);
            ViewBag.idContenido = new SelectList(db.Contenido, "idContenido", "strDescripcion", encuadre.idContenido);
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idEmpleado", "strNombre", encuadre.idEmpleado);
            ViewBag.idProposito = new SelectList(db.Proposito, "idProposito", "strDescripcion", encuadre.idProposito);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", encuadre.idTema);

            ViewBag.idAprendizaje = new SelectList(db.Aprendizaje, "idAprendizaje", "strDescripcion", encuadre.idAprendizaje);
            return View(encuadre);
        }

        // GET: Encuadres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Encuadre encuadre = db.Encuadre.Find(id);
            if (encuadre == null)
            {
                return HttpNotFound();
            }
            return View(encuadre);
        }

        // POST: Encuadres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Encuadre encuadre = db.Encuadre.Find(id);
            db.Encuadre.Remove(encuadre);
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
