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
    public class ComarcasController : Controller
    {
        private ContextoDados db = new ContextoDados();

        // GET: Comarcas
        public ActionResult Index()
        {
            return View(db.Comarcas.ToList());
        }

        // GET: Comarcas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comarca comarca = db.Comarcas.Find(id);
            if (comarca == null)
            {
                return HttpNotFound();
            }
            return PartialView(comarca);
        }

        // GET: Comarcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comarcas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] Comarca comarca)
        {
            if (ModelState.IsValid)
            {
                db.Comarcas.Add(comarca);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comarca);
        }

        // GET: Comarcas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comarca comarca = db.Comarcas.Find(id);
            if (comarca == null)
            {
                return HttpNotFound();
            }
            return View(comarca);
        }

        // POST: Comarcas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] Comarca comarca)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comarca).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comarca);
        }

        // GET: Comarcas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comarca comarca = db.Comarcas.Find(id);
            if (comarca == null)
            {
                return HttpNotFound();
            }
            return View(comarca);
        }

        // POST: Comarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comarca comarca = db.Comarcas.Find(id);
            db.Comarcas.Remove(comarca);
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
