using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class ShoppingCart
    {
        private IValueCalculator calc;
        public IEnumerable<Product> Products { get; set; }
        public ShoppingCart(IValueCalculator calcPram)
        {
            calc = calcPram;
        }
        public decimal CalculateProductTotal()
        {
            return calc.ValueProduct(Products);
        }
    }
}