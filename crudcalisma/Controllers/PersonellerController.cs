using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crudcalisma.Models;

namespace crudcalisma.Controllers
{
    public class PersonellerController : Controller
    {
        private crudEntities1 db = new crudEntities1();

        // GET: Personeller
        public ActionResult Index()
        {
            return View(db.Tbl_Personeller.ToList());
        }

        // GET: Personeller/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Personeller tbl_Personeller = db.Tbl_Personeller.Find(id);
            if (tbl_Personeller == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Personeller);
        }

        // GET: Personeller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personeller/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "personelid,personelad,personelsoyad,personelyas,personeldogumtarihi")] Tbl_Personeller tbl_Personeller)
        {
            if (ModelState.IsValid)
            {
                db.Tbl_Personeller.Add(tbl_Personeller);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Personeller);
        }

        // GET: Personeller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Personeller tbl_Personeller = db.Tbl_Personeller.Find(id);
            if (tbl_Personeller == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Personeller);
        }

        // POST: Personeller/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "personelid,personelad,personelsoyad,personelyas,personeldogumtarihi")] Tbl_Personeller tbl_Personeller)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Personeller).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Personeller);
        }

        // GET: Personeller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tbl_Personeller tbl_Personeller = db.Tbl_Personeller.Find(id);
            if (tbl_Personeller == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Personeller);
        }

        // POST: Personeller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tbl_Personeller tbl_Personeller = db.Tbl_Personeller.Find(id);
            db.Tbl_Personeller.Remove(tbl_Personeller);
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
