using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator:IValueCalculator
    {
        public decimal ValueProduct(IEnumerable<Product> Products)
        {
            decimal sum = Products.Sum(p => p.Price);
            return sum;
        }
    }
}