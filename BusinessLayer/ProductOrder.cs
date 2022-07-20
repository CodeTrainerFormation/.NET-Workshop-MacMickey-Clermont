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
        private int counterOfProducts;
        private static int counterOfOrders = 0;

        public int OrderId { get; private set; }

        public ProductOrder()
        {
            this.products = new List<Product>();
            this.counterOfProducts = 0;
            this.OrderId = ++ProductOrder.counterOfOrders;
        }

        //public ProductOrder(List<Product> products)
        //{
        //    this.products = products;
        //}

        // --- Create ---
        public void AddProduct(Product product)
        {
            product.Id = ++counterOfProducts;
            this.products.Add(product);
        }

        public void CreateProduct(string name, decimal price, string description, int stockpiled)
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
        public void UpdateProduct(Product product)
        {
            Product p = this.products.Single(p => p.Id == product.Id);

            //if(!string.IsNullOrWhiteSpace(product.Name) 
            //    && p.Name != product.Name)
            //{
            //    p.Name = product.Name;
            //}

            p.Name = product.Name;
            p.Price = product.Price;
            p.Description = product.Description;
            p.Stockpiled = product.Stockpiled;
        }

        public void UpdateProduct(int id, string name, decimal price, string description, int stockpiled)
        {
            //Product p = this.products.Single(p => p.Id == id);

            //p.Name = name;
            //p.Price = price;
            //p.Description = description;
            //p.Stockpiled = stockpiled;

            Product product = new Product()
            {
                Id = id,
                Name = name,
                Price = price,
                Description = description,
                Stockpiled = stockpiled
            };

            this.UpdateProduct(product);
        }

        // Delete
        public void DeleteProduct(Product product)
        {
            this.products.Remove(product);
        }

        public void DeleteProduct(int id)
        {
            Product p = this.products.Single(p => p.Id == id);
            this.DeleteProduct(p);
        }

        public void DeleteProductRemoveAll(int id)
        {
            this.products.RemoveAll(products => products.Id == id);
        }

        // Queries
        public Product? GetProductById(int id)
        {
            return this.products.SingleOrDefault(p => p.Id == id);
        }

        public Product? GetProductByName(string name)
        {
            return this.products.FirstOrDefault(p => p.Name == name);
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Product> GetProductsWithPriceInferiorAt(decimal price)
        {
            return this.products.Where(p => p.Price < price).ToList();
        }

        public List<Product> GetProductsWithPriceInferiorAtAndNameStartBy(decimal price, char character)
        {
            return this.products.Where(p => p.Price < price && p.Name.StartsWith(character)).ToList();
        }
    }
}
