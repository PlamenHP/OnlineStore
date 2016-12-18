namespace OnlineStore.Web.Areas.Admin.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    public class CategoryViewModel
    {
        [Required]
        public string Name { get; set; }

        public HttpPostedFileBase ImageFromView { get; set; }

        public string ImageToView { get; set; }
    }
}