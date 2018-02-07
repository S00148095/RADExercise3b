using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Exercise3bShop.DAL;
using Exercise3bShop.Models;

namespace Exercise3bShop.Controllers
{
    public class ShopItemsController : Controller
    {
        private IItemRepository db;

        public ShopItemsController() {
            db = new ShopItemRepository(new ShopContext());
        }

        // GET: ShopItems
        public ActionResult Index()
        {
            return View(db.GetItems());
        }

        // GET: ShopItems/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopItem shopItem = db.GetItemByID(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // GET: ShopItems/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Cost,Class,ImageURL")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                db.InsertItem(shopItem);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(shopItem);
        }

        // GET: ShopItems/Edit/5
        public ActionResult Edit(int id)
        {
            ShopItem shopItem = db.GetItemByID(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: ShopItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Cost,Class,ImageURL")] ShopItem shopItem)
        {
            if (ModelState.IsValid)
            {
                db.UpdateItem(shopItem);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(shopItem);
        }

        // GET: ShopItems/Delete/5
        public ActionResult Delete(int id)
        {
            ShopItem shopItem = db.GetItemByID(id);
            if (shopItem == null)
            {
                return HttpNotFound();
            }
            return View(shopItem);
        }

        // POST: ShopItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteItem(id);
            db.Save();
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
