using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using EssentialTools.Models;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private Product[] products =
        {
            new Product { Name = "Kayak",Category = "WaterSports",Price = 275m },
            new Product { Name = "Lifejacket",Category = "WaterSprots",Price = 48.95m},
            new Product { Name = "Soccer ball",Category = "Soccer",Price = 19.59m},
            new Product { Name = "Corner flag",Category = "Soccer",Price = 34.95m}
        };
        // GET: Default
        public ActionResult Index()
        {
            //First stage:create the instance of the Ninject，that is the kernel object which is used to resolve the dependancy and creage a new object.
            IKernel ninjectKernel = new StandardKernel();

            //Second stage:configure the kernel of Ninject in order to indecate which class should be used to instantiate the interface
            ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();

            //Third stage:create object of the interface via the Get method
            IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
            //IValueCalculator calc = new LinqValueCalculator();
            ShoppingCart cart = new ShoppingCart(calc);
            cart.Products = products;
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
    }
}