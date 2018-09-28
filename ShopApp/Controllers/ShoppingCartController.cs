using ShopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ShopApp.Controllers
{
    public class ShoppingCartController : Controller
    {

        ShopEntities db = new ShopEntities();
        // GET: ShoppingCart

        private string StrCart = "Cart";
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult OrderNow(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[StrCart] ==null)
            {
                List<CartViewModel> ListCart = new List<CartViewModel>
                {
                    new CartViewModel(db.tblProducts.Find(id), 1)
                };
                     Session[StrCart] = ListCart;
            }
            else
            {
                List<CartViewModel> ListCart = (List<CartViewModel>)Session[StrCart];
                int ItemNumber = 0;
                int check = isExistingCheck(id);
                if (check == -1)
                {
                    ListCart.Add(new CartViewModel(db.tblProducts.Find(id), 1));
                }
                else
                {
                   
                    ListCart[check].Quantity ++;
                    ItemNumber = ItemNumber++;
                    Session["NoOfItems"] = ItemNumber;
                    //ListCart.Add(new CartViewModel(db.tblProducts.Find(id), 1));
                    Session[StrCart] = ListCart;
                }
            }
            return View("Index");
        }

        private int isExistingCheck(int ? id)
        {
            List<CartViewModel> ListCart = (List <CartViewModel>) Session[StrCart];

            for (int i = 0; i < ListCart.Count; i++)
            {
                if (ListCart[i].Product.ProductId == id) return i; 
            }
            return -1;
        }


        public ActionResult Delete(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int Check = isExistingCheck(id);
            List<CartViewModel> ListCart = (List<CartViewModel>)Session[StrCart];

            ListCart.RemoveAt(Check);


            //if (Session[StrCart]==null)
            //{
            //    Response.Redirect("/Home/index");
            //}
            //else
            //{
            //    ListCart.RemoveAt(Check);
            //}
            return View("Index");
        }


        public ActionResult UpdateProduct(FormCollection frc)
        {
            string[] quantities = frc.GetValues("QtySelected");

            List<CartViewModel> lstCart = (List<CartViewModel>) Session[StrCart];

            for (int i = 0; i < lstCart.Count; i++)
            {
                lstCart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session[StrCart] = lstCart;
            return View("Index");
        }


        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblProduct ProductDetails = db.tblProducts.Find(id);
            if (ProductDetails == null)
            {
                return HttpNotFound();
            }
            return View(ProductDetails);
        }


        public ActionResult CheckOut()
        {
           
            return View("CheckOut");
        }

        public ActionResult ProcessOrder(FormCollection frc)
        {
            List<CartViewModel> LstCrt = (List<CartViewModel>) Session[StrCart];
            //1. save the order

           //Generate 
            Random x = new Random();
            long GeneratedOrderName = x.Next(0, 1000);

            tblOrder orders = new tblOrder()
            {
                //OrderName = GeneratedOrderName.ToString()+ "0.00" + GeneratedOrderName.ToString(),
                OrderName = "ORDER" + GeneratedOrderName.ToString(),
                CustomerFirstName = frc["billing_first_name"],
                CustomerLastName = frc["billing_last_name"],
                CompanyName = frc["billing_company"],
                Country = frc["billing_country"],
                Street = frc["billing_address_1"],
                Apartment = frc["billing_address_2"],
                Town = frc["billing_city"],
                State = frc["billing_state"],
                ZIP = frc["billing_postcode"],
                Phone  = frc["billing_phone"],
                Email = frc["billing_email"],
                OrderNote = frc["order_comments"],
                OrderDate= DateTime.UtcNow,
                PaymentType= "Cash",
                Status="Processing"
            };

            db.tblOrders.Add(orders);
            db.SaveChanges();
            //2. save the order values
            foreach (CartViewModel cartItem in LstCrt)
            {
                tblOrderDetail orderDetail = new tblOrderDetail()
                {
                    OrderId = orders.OrderId,
                    ProductId= cartItem.Product.ProductId,
                  Price= cartItem.Product.Price.ToString(),
                    Quantity= cartItem.Quantity.ToString()

                };
                db.tblOrderDetails.Add(orderDetail);
                db.SaveChanges();
            }

            //3. Remove Shopping cart session
            Session.Remove(StrCart);
            return View("OrderSuccess");
        }

    }
}