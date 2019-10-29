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
    public class EmpleadoesController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Empleadoes
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.CatEstadoRegistro).Include(e => e.CatNivel).Include(e => e.CatPuesto).Include(e => e.Instituciones);
            return View(empleado.ToList());
        }

        // GET: Empleadoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.idCatEstadoR = new SelectList(db.CatEstadoRegistro, "idEstadoRegistro", "strValor");
            ViewBag.idNivel = new SelectList(db.CatNivel, "idNivel", "strDescripcion");
            ViewBag.idPuesto = new SelectList(db.CatPuesto, "idPuesto", "strDescripcion");
            ViewBag.idInstitucion = new SelectList(db.Instituciones, "idInstintucion", "strNombre");
            return View();
        }

        // POST: Empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpleado,strNombre,strAPaterno,strAMaterno,idNivel,strRFC,strCurp,strFechaNacimiento,idPuesto,idInstitucion,idCatEstadoR")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCatEstadoR = new SelectList(db.CatEstadoRegistro, "idEstadoRegistro", "strValor", empleado.idCatEstadoR);
            ViewBag.idNivel = new SelectList(db.CatNivel, "idNivel", "strDescripcion", empleado.idNivel);
            ViewBag.idPuesto = new SelectList(db.CatPuesto, "idPuesto", "strDescripcion", empleado.idPuesto);
            ViewBag.idInstitucion = new SelectList(db.Instituciones, "idInstintucion", "strNombre", empleado.idInstitucion);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCatEstadoR = new SelectList(db.CatEstadoRegistro, "idEstadoRegistro", "strValor", empleado.idCatEstadoR);
            ViewBag.idNivel = new SelectList(db.CatNivel, "idNivel", "strDescripcion", empleado.idNivel);
            ViewBag.idPuesto = new SelectList(db.CatPuesto, "idPuesto", "strDescripcion", empleado.idPuesto);
            ViewBag.idInstitucion = new SelectList(db.Instituciones, "idInstintucion", "strNombre", empleado.idInstitucion);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idEmpleado,strNombre,strAPaterno,strAMaterno,idNivel,strRFC,strCurp,strFechaNacimiento,idPuesto,idInstitucion,idCatEstadoR")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCatEstadoR = new SelectList(db.CatEstadoRegistro, "idEstadoRegistro", "strValor", empleado.idCatEstadoR);
            ViewBag.idNivel = new SelectList(db.CatNivel, "idNivel", "strDescripcion", empleado.idNivel);
            ViewBag.idPuesto = new SelectList(db.CatPuesto, "idPuesto", "strDescripcion", empleado.idPuesto);
            ViewBag.idInstitucion = new SelectList(db.Instituciones, "idInstintucion", "strNombre", empleado.idInstitucion);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
