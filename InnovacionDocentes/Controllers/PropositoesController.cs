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
    public class PropositoesController : Controller
    {
        private innovaciontibdEntities db = new innovaciontibdEntities();

        // GET: Propositoes
        public ActionResult Index()
        {
            var proposito = db.Proposito.Include(p => p.CatTipoCompetencia).Include(p => p.Tema);
            return View(proposito.ToList());
        }

        // GET: Propositoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposito proposito = db.Proposito.Find(id);
            if (proposito == null)
            {
                return HttpNotFound();
            }
            return View(proposito);
        }

        // GET: Propositoes/Create
        public ActionResult Create()
        {
            ViewBag.idCatTipoCompetencia = new SelectList(db.CatTipoCompetencia, "idTipoCom", "strDescripcion");
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre");
            return View();
        }

        // POST: Propositoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProposito,strDescripcion,idTema,idCatTipoCompetencia")] Proposito proposito)
        {
            if (ModelState.IsValid)
            {
                db.Proposito.Add(proposito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCatTipoCompetencia = new SelectList(db.CatTipoCompetencia, "idTipoCom", "strDescripcion", proposito.idCatTipoCompetencia);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", proposito.idTema);
            return View(proposito);
        }

        // GET: Propositoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposito proposito = db.Proposito.Find(id);
            if (proposito == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCatTipoCompetencia = new SelectList(db.CatTipoCompetencia, "idTipoCom", "strDescripcion", proposito.idCatTipoCompetencia);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", proposito.idTema);
            return View(proposito);
        }

        // POST: Propositoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProposito,strDescripcion,idTema,idCatTipoCompetencia")] Proposito proposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCatTipoCompetencia = new SelectList(db.CatTipoCompetencia, "idTipoCom", "strDescripcion", proposito.idCatTipoCompetencia);
            ViewBag.idTema = new SelectList(db.Tema, "idTema", "strNombre", proposito.idTema);
            return View(proposito);
        }

        // GET: Propositoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Proposito proposito = db.Proposito.Find(id);
            if (proposito == null)
            {
                return HttpNotFound();
            }
            return View(proposito);
        }

        // POST: Propositoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Proposito proposito = db.Proposito.Find(id);
            db.Proposito.Remove(proposito);
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
