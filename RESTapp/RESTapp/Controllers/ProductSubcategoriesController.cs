using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Client.Models;
using RESTapp.Models;

namespace RESTapp.Controllers
{
    public class ProductSubcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProductSubcategories
        public ActionResult Index()
        {
            var productSubcategories = db.ProductSubcategories.Include(p => p.ProductCategory);
            return View(productSubcategories.ToList());
        }

        // GET: ProductSubcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubcategory productSubcategory = db.ProductSubcategories.Find(id);
            if (productSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Create
        public ActionResult Create()
        {
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name");
            return View();
        }

        // POST: ProductSubcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductSubcategoryID,ProductCategoryID,Name,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.ProductSubcategories.Add(productSubcategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", productSubcategory.ProductCategoryID);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubcategory productSubcategory = db.ProductSubcategories.Find(id);
            if (productSubcategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", productSubcategory.ProductCategoryID);
            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductSubcategoryID,ProductCategoryID,Name,ModifiedDate")] ProductSubcategory productSubcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSubcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories, "ProductCategoryID", "Name", productSubcategory.ProductCategoryID);
            return View(productSubcategory);
        }

        // GET: ProductSubcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSubcategory productSubcategory = db.ProductSubcategories.Find(id);
            if (productSubcategory == null)
            {
                return HttpNotFound();
            }
            return View(productSubcategory);
        }

        // POST: ProductSubcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductSubcategory productSubcategory = db.ProductSubcategories.Find(id);
            db.ProductSubcategories.Remove(productSubcategory);
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
