using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopApp.Models
{
    public class CartViewModel
    {

        public tblProduct Product { get; set; }
        public int Quantity { get; set; }

        public CartViewModel(tblProduct product,int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}