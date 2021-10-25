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
    public class AuctionBidsController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: AuctionBids
        public ActionResult Index()
        {
            var auctionBids = db.AuctionBids.Include(a => a.Auction).Include(a => a.Bidder);
            return View(auctionBids.ToList());
        }

        // GET: AuctionBids/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionBid auctionBid = db.AuctionBids.Find(id);
            if (auctionBid == null)
            {
                return HttpNotFound();
            }
            return View(auctionBid);
        }

        // GET: AuctionBids/Create
        public ActionResult Create()
        {
            ViewBag.AuctionId = new SelectList(db.Auctions, "ID", "ID");
            ViewBag.BidderId = new SelectList(db.Bidders, "ID", "NameEn");
            return View();
        }

        // POST: AuctionBids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bid,Profit,AuctionId,BidderId,CreatedOn")] AuctionBid auctionBid)
        {
            if (ModelState.IsValid)
            {
                db.AuctionBids.Add(auctionBid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionId = new SelectList(db.Auctions, "ID", "ID", auctionBid.AuctionId);
            ViewBag.BidderId = new SelectList(db.Bidders, "ID", "NameEn", auctionBid.BidderId);
            return View(auctionBid);
        }

        // GET: AuctionBids/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionBid auctionBid = db.AuctionBids.Find(id);
            if (auctionBid == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionId = new SelectList(db.Auctions, "ID", "ID", auctionBid.AuctionId);
            ViewBag.BidderId = new SelectList(db.Bidders, "ID", "NameEn", auctionBid.BidderId);
            return View(auctionBid);
        }

        // POST: AuctionBids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Bid,Profit,AuctionId,BidderId,CreatedOn")] AuctionBid auctionBid)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auctionBid).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionId = new SelectList(db.Auctions, "ID", "ID", auctionBid.AuctionId);
            ViewBag.BidderId = new SelectList(db.Bidders, "ID", "NameEn", auctionBid.BidderId);
            return View(auctionBid);
        }

        // GET: AuctionBids/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AuctionBid auctionBid = db.AuctionBids.Find(id);
            if (auctionBid == null)
            {
                return HttpNotFound();
            }
            return View(auctionBid);
        }

        // POST: AuctionBids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AuctionBid auctionBid = db.AuctionBids.Find(id);
            db.AuctionBids.Remove(auctionBid);
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
