namespace OnlineStore.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using OnlineStore.Models;
    using Web.Controllers;
    using Data.UnitOfWork;
    using ViewModels;

    [Authorize(Roles = "Admin")]
    public class CategoriesController : BaseController
    {
        public CategoriesController(IStoreDb data)
            :base(data)
        {
        }

        // GET: Admin/Categories
        public ActionResult Index()
        {
            var categories = this.Data.Categories
                    .All()
                    .OrderBy(x => x.Name)
                    .ToList();

            var categoryViewModel = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return View(categoryViewModel);
        }

        // GET: Admin/Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = this.Mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = this.Mapper.Map<Category>(categoryViewModel);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", categoryViewModel.Id);
            return View(categoryViewModel);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            var categoryViewModel = this.Mapper.Map<CategoryViewModel>(category);
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", categoryViewModel.Id);
            return View(categoryViewModel);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                this.Data.Categories.Update(this.Mapper.Map<Category>(categoryViewModel));
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name", categoryViewModel.Id);
            return View(categoryViewModel);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = Data.Categories.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            var categoryViewModel = this.Mapper.Map<CategoryViewModel>(category);
            return View(categoryViewModel);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = Data.Categories.GetById(id);
            Data.Categories.Delete(category);
            Data.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
