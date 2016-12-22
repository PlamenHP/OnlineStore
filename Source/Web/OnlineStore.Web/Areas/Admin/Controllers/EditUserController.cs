namespace OnlineStore.Web.Areas.Admin.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using OnlineStore.Models;
    using Web.Controllers;
    using Data.UnitOfWork;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ViewModels;
    using Data;
    using Microsoft.AspNet.Identity.Owin;
    using System.Web.Security;

    [Authorize(Roles = "Admin")]
    public class EditUserController : BaseController
    {
        public EditUserController(IStoreDb data)
            : base(data)
        {
        }

        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: User/List
        public ActionResult List()
        {

            var users = this.Data.Users.All().ToList();

            var admins = GetAdminUserNames(users, Data);
            ViewBag.Admins = admins;

            return View(users);

        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, IStoreDb data)
        {
            // Create user manager
            var userManager = Request
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            var admins = new HashSet<string>();

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }


        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            //validate id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get user from DB
            var user = Data.Users.All().FirstOrDefault(x=>x.Id == id);

            // Check if user exists
            if (user == null)
            {
                return HttpNotFound();
            }


            // Create a view model
            var viewModel = new EditUserViewModel();
            viewModel.User = user;
            viewModel.Roles = GetUserRoles(user, Data);

            // Pass the model to the view
            return View(viewModel);
        }

        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
            // Check if model is valid
            if (ModelState.IsValid)
            {

                // Get user from Data
                var user = Data.Users.All().FirstOrDefault(x => x.Id == id);

                // Check if user exists
                if (user == null)
                {
                    return HttpNotFound();
                }

                // If password field is not empty, change password
                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    var hasher = new PasswordHasher();
                    var passwordHash = hasher.HashPassword(viewModel.Password);
                    user.PasswordHash = passwordHash;
                }

                // Set user properties
                user.Email = viewModel.User.Email;
                user.FirstName = viewModel.User.FirstName;
                user.UserName = viewModel.User.LastName;
                this.SetUserRoles(viewModel, user, Data);

                // Save changes
                Data.SaveChanges();
                return RedirectToAction("List");

            }

            return View(viewModel);
        }

        // GET: User/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // get user from Data
            var user = Data.Users.All().FirstOrDefault(x => x.Id == id);

            // Check if user exists
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);

        }

        // POST: User/Delete
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // Get user from Data
            var user = Data.Users.All().FirstOrDefault(x => x.Id == id);

            // Delete user and save changes
            Data.Users.Delete(user);
            Data.SaveChanges();

            return RedirectToAction("List");

        }

        private void SetUserRoles(EditUserViewModel viewModel, ApplicationUser user, IStoreDb Data)
        {
            var userManager = HttpContext
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            foreach (var role in viewModel.Roles)
            {
                if (role.IsSelected && !userManager.IsInRole(user.Id, role.Name))
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.IsSelected && userManager.IsInRole(user.Id, role.Name))
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }

        private IList<Role> GetUserRoles(ApplicationUser user, IStoreDb db)
        {
            // Create user manager
            var userManager = Request
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            // Get all  application roles
            var roles = db.IdentityRoles.All()
                .Select(r => r.Name)
                .OrderBy(r => r)
                .ToList();

            // For each application role, check if the user has it
            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            // Return a list with all roles
            return userRoles;
        }
    }
}

