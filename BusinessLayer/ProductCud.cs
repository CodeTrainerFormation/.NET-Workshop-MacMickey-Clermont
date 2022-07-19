using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ProductOrder
    {
        private List<Product> products;
        private int counter;

        public ProductOrder()
        {
            this.products = new List<Product>();
            this.counter = 0;
        }

        //public ProductOrder(List<Product> products)
        //{
        //    this.products = products;
        //}

        // --- Create ---
        public void AddProduct(Product product)
        {
            product.Id = ++counter;
            this.products.Add(product);
        }

        public void Create(string name, decimal price, string description, int stockpiled)
        {
            Product product = new Product()
            {
                Name = name,
                Price = price,
                Description = description,
                Stockpiled = stockpiled
            };

            this.AddProduct(product);
        }

        //public void Create(string name, decimal price, string description, int stockpiled)
        //{
        //    Product product = new Product()
        //    {
        //        Id = ++counter,
        //        Name = name,
        //        Price = price,
        //        Description = description,
        //        Stockpiled = stockpiled
        //    };
        //
        //    this.products.Add(product);
        //}

        // Update
        // Delete
    }
}
