using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASApp.Models
{
    public static class ProductRep
    {
        static List<Product> Products { get; }
        static int nextId = 3;
        static ProductRep()
        {
            Products = new List<Product>
        {
            new Product {Id = 1, Name = "Coffe", Price = 330 },
            new Product {Id = 2, Name = "Milk", Price = 260 }
        };

        }

        public static List<Product> GetAll() => Products;

        public static Product? Get(int id) => Products.FirstOrDefault(p => p.Id == id);

        public static void Add(Product product)
        {
            product.Id = nextId++;
            Products.Add(product);
        }

        public static void Delete(int id)
        {
            var product = Get(id);
            if (product is null)
                return;

            Products.Remove(product);
        }

        public static void Update(Product product)
        {
            var index = Products.FindIndex(p => p.Id == product.Id);
            if (index == -1)
                return;

            Products[index] = product;
        }
    }
}
