using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Auction.Business.Repositories;
using Auction.Business.Repositories.Interfaces;
using Auction.DAL.ApplicationDBContext;
using Auction.DAL.Entities;

namespace AuctionWebApp.Controllers
{
    public class BiddersController : Controller
    {
        //private ApplicationDBContext db = new ApplicationDBContext();

        private UnitOfWork<ApplicationDBContext> unitOfWork = new UnitOfWork<ApplicationDBContext>();
        private GenericRepository<Bidder> repository;
        private IBidderRepository bidderRepository;

        public BiddersController()
        {
            repository = new GenericRepository<Bidder>(unitOfWork);
        }

        // GET: Bidders
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);

            // return View(db.Bidders.ToList());
        }

        // GET: Bidders/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Bidder bidder = db.Bidders.Find(id);
            //if (bidder == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(bidder);


            Bidder model = repository.GetById(id);
            return View(model);
        }

        // GET: Bidders/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] Bidder bidder)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Bidders.Add(bidder);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(bidder);

            try
            {
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    repository.Insert(bidder);
                    unitOfWork.Save();
                    //Do Some Other Task with the Database
                    //If everything is working then commit the transaction else rollback the transaction
                    unitOfWork.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                //Log the exception and rollback the transaction
                unitOfWork.Rollback();
            }
            return View();

        }

        // GET: Bidders/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Bidder bidder = db.Bidders.Find(id);
            //if (bidder == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(bidder);

            Bidder model = repository.GetById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Bidder bidder)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(bidder).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(bidder);

            if (ModelState.IsValid)
            {
                repository.Update(bidder);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(bidder);
            }

        }

        // GET: Bidders/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Bidder bidder = db.Bidders.Find(id);
            //if (bidder == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(bidder);

            Bidder model = repository.GetById(id);
            return View(model);
        }

        // POST: Bidders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Bidder bidder = db.Bidders.Find(id);
            //db.Bidders.Remove(bidder);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            Bidder model = repository.GetById(id);
            repository.Delete(model);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
