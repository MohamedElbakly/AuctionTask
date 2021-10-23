using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.DAL.ApplicationDBContext;
using Auction.DAL.Entities;

namespace AuctionWebApp.Controllers
{
    public class BiddersController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Bidders
        public ActionResult Index()
        {
            return View(db.Bidders.ToList());
        }

        // GET: Bidders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

        // GET: Bidders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bidders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                db.Bidders.Add(bidder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bidder);
        }

        // GET: Bidders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

        // POST: Bidders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Bidder bidder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bidder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bidder);
        }

        // GET: Bidders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bidder bidder = db.Bidders.Find(id);
            if (bidder == null)
            {
                return HttpNotFound();
            }
            return View(bidder);
        }

        // POST: Bidders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bidder bidder = db.Bidders.Find(id);
            db.Bidders.Remove(bidder);
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
