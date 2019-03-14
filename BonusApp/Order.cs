using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonusApp
{
    public class Order
    {
        private List<Product> _products = new List<Product>();

        public BonusProvider Bonus { get; set; }

        public void AddProduct(Product p)
        {
            _products.Add(p);
        }
        public double GetValueOfProducts()
        {
            // gammel kode
            //double valueOfProducts = 0.0;

            //foreach (Product p in _products)
            //{
            //    valueOfProducts += p.Value;
            //}

            //return valueOfProducts;


            return _products.Sum(x => x.Value);
        }
        public double GetValueOfProducts(DateTime date)
        {
            //var filteredProducts = from  in _products
            //                         where date(s)
            //                         select s;
            //return Where(d => date <= );
            
        }
        public double GetBonus()
        {
            return Bonus(GetValueOfProducts());
        }
        public double GetTotalPrice()
        {
            return GetValueOfProducts()-GetBonus();
        }
    }
}
