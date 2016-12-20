namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using OnlineStore.Models;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage = "Password does  not mathch.")]
        public string ConfirmPassword { get; set; }

        public IList<Role> Roles { get; set; }
    }
}