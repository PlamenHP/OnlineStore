using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStore.Web.Controllers;
using OnlineStore.Data.UnitOfWork;
using OnlineStore.Web.Areas.Admin.ViewModels;
using OnlineStore.Infrastructure.Mapping;
using AutoMapper.QueryableExtensions;

namespace OnlineStore.Web.Areas.Admin.Controllers
{
    public class ProductsController : BaseController
    {
        public ProductsController(IStoreDb data)
            :base(data)
        {
        }

        // GET: Admin/Products
        public ActionResult Index()
        {
            var productViewModel = this.Data.Products
                    .AllWithDeleted()
                    .OrderBy(x => x.Name)
                    .MapTo<ProductViewModel>()
                    .ToList();

            return View(productViewModel);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = this.Data.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productViewModel = this.Mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Data.Categories.All(), "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = this.Mapper.Map<Product>(productViewModel);
                this.Data.Products.Add(product);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var product = this.Data.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productViewModel = this.Mapper.Map<ProductViewModel>(product);
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                //var product = this.Data.Products.GetById(productViewModel.Id);
                this.Data.Products.Update(this.Mapper.Map<Product>(productViewModel));
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", productViewModel.CategoryId);
            return View(productViewModel);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = this.Data.Products.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            var productViewModel = this.Mapper.Map<ProductViewModel>(product);
            return View(productViewModel);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = this.Data.Products.GetById(id);
            this.Data.Products.Delete(product);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
