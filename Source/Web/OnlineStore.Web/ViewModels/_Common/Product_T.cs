namespace OnlineStore.Web.ViewModels._Common
{
    using System;

    public abstract class Product_T
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageToView { get; set; }

        public Decimal Price { get; set; }
    }
}