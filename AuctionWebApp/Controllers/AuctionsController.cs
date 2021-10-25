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
using Auction.DAL.Models;

namespace AuctionWebApp.Controllers
{
    public class AuctionsController : Controller
    {
        private ApplicationDBContext db = new ApplicationDBContext();

        // GET: Auctions
        public ActionResult Index()
        {
            var auctions = db.Auctions.Include(a => a.AuctionItem);
            return View(auctions.ToList());
        }

        // GET: Auctions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                ViewBag.BidderId = new SelectList(db.Bidders, "ID", "NameEn");

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction.DAL.Entities.Auction auction = db.Auctions.Find(id);

            var ViewModel = new AuctionViewModel
            {
                AuctionID = auction.ID,
                AuctionItemName = auction.AuctionItem.Name,
                AuctionItemPrice = auction.AuctionItem.StartPrice,
                Bid = 0
            };


            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(AuctionViewModel auctionViewModel)
        {
            if (ModelState.IsValid)
            {
                //db.Auctions.Add(auction);
                //db.SaveChanges();
                return View();
            }

            return View(auctionViewModel);
        }





        // GET: Auctions/Create
        public ActionResult Create()
        {
            ViewBag.AuctionItemId = new SelectList(db.AuctionItems, "ID", "Name");
            return View();
        }

        // POST: Auctions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AuctionItemId,CreatedOn")] Auction.DAL.Entities.Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Auctions.Add(auction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuctionItemId = new SelectList(db.AuctionItems, "ID", "Name", auction.AuctionItemId);
            return View(auction);
        }

        // GET: Auctions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction.DAL.Entities.Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuctionItemId = new SelectList(db.AuctionItems, "ID", "Name", auction.AuctionItemId);
            return View(auction);
        }

        // POST: Auctions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AuctionItemId,CreatedOn")] Auction.DAL.Entities.Auction auction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(auction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuctionItemId = new SelectList(db.AuctionItems, "ID", "Name", auction.AuctionItemId);
            return View(auction);
        }

        // GET: Auctions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Auction.DAL.Entities.Auction auction = db.Auctions.Find(id);
            if (auction == null)
            {
                return HttpNotFound();
            }
            return View(auction);
        }

        // POST: Auctions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auction.DAL.Entities.Auction auction = db.Auctions.Find(id);
            db.Auctions.Remove(auction);
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
