using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModalDemo.Models;

namespace ModalDemo.Controllers
{
    public class VarasController : Controller
    {
        private ContextoDados db = new ContextoDados();

        // GET: Varas
        public ActionResult Index()
        {
            var varas = db.Varas.Include(v => v.Comarca);
            return View(varas.ToList());
        }

        public PartialViewResult ListarVarasPorComarca(int id)
        {
            return PartialView(db.Varas.Where(v => v.ComarcaId == id).ToList());
        }

        // GET: Varas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vara vara = db.Varas.Find(id);
            if (vara == null)
            {
                return HttpNotFound();
            }
            return View(vara);
        }

        // GET: Varas/Create
        public ActionResult Create()
        {
            ViewBag.ComarcaId = new SelectList(db.Comarcas, "Id", "Nome");
            return View();
        }

        // POST: Varas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ComarcaId")] Vara vara)
        {
            if (ModelState.IsValid)
            {
                db.Varas.Add(vara);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComarcaId = new SelectList(db.Comarcas, "Id", "Nome", vara.ComarcaId);
            return View(vara);
        }

        // GET: Varas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vara vara = db.Varas.Find(id);
            if (vara == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComarcaId = new SelectList(db.Comarcas, "Id", "Nome", vara.ComarcaId);
            return View(vara);
        }

        // POST: Varas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,ComarcaId")] Vara vara)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vara).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComarcaId = new SelectList(db.Comarcas, "Id", "Nome", vara.ComarcaId);
            return View(vara);
        }

        // GET: Varas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vara vara = db.Varas.Find(id);
            if (vara == null)
            {
                return HttpNotFound();
            }
            return View(vara);
        }

        // POST: Varas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vara vara = db.Varas.Find(id);
            db.Varas.Remove(vara);
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
