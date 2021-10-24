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
    public class AuctionItemsController : Controller
    {
        //private ApplicationDBContext db = new ApplicationDBContext();

        private UnitOfWork<ApplicationDBContext> unitOfWork = new UnitOfWork<ApplicationDBContext>();
        private GenericRepository<AuctionItem> repository;
        private IAuctionItemRepository auctionItemRepository;

        public AuctionItemsController()
        {
            repository = new GenericRepository<AuctionItem>(unitOfWork);
        }

        // GET: AuctionItems
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);

            //return View(db.AuctionItems.ToList());
        }

        // GET: AuctionItems/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AuctionItem auctionItem = db.AuctionItems.Find(id);
            //if (auctionItem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(auctionItem);

            AuctionItem model = repository.GetById(id);
            return View(model);
        }

        // GET: AuctionItems/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( AuctionItem auctionItem)
        {
            //if (ModelState.IsValid)
            //{
            //    db.AuctionItems.Add(auctionItem);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(auctionItem);

            try
            {
                unitOfWork.CreateTransaction();
                if (ModelState.IsValid)
                {
                    repository.Insert(auctionItem);
                    unitOfWork.Save();
                    unitOfWork.Commit();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
            }
            return View();

        }

        // GET: AuctionItems/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AuctionItem auctionItem = db.AuctionItems.Find(id);
            //if (auctionItem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(auctionItem);

            AuctionItem model = repository.GetById(id);
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AuctionItem auctionItem)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(auctionItem).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(auctionItem);

            if (ModelState.IsValid)
            {
                repository.Update(auctionItem);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(auctionItem);
            }
        }

        // GET: AuctionItems/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //AuctionItem auctionItem = db.AuctionItems.Find(id);
            //if (auctionItem == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(auctionItem);

            AuctionItem model = repository.GetById(id);
            return View(model);
        }

        // POST: AuctionItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //AuctionItem auctionItem = db.AuctionItems.Find(id);
            //db.AuctionItems.Remove(auctionItem);
            //db.SaveChanges();
            //return RedirectToAction("Index");

            AuctionItem model = repository.GetById(id);
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
