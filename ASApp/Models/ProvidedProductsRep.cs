using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{
    public static class ProvidedProductsRep
    {
        static List<ProvidedProducts> ProvidedProductss { get; }
        static int nextId = 3;
        static ProvidedProductsRep()
        {
            ProvidedProductss = new List<ProvidedProducts>
        {
            new ProvidedProducts {Id = 1, ProductId = 1, ProductQuantity =10},
            new ProvidedProducts {Id = 2, ProductId = 2, ProductQuantity =100}
        };

        }

        public static List<ProvidedProducts> GetAll() => ProvidedProductss;

        public static ProvidedProducts? Get(int id) => ProvidedProductss.FirstOrDefault(p => p.Id == id);

        public static void Add(ProvidedProducts providedProducts)
        {
            providedProducts.Id = nextId++;
            ProvidedProductss.Add(providedProducts);
        }

        public static void Delete(int id)
        {
            var providedProducts = Get(id);
            if (providedProducts is null)
                return;

            ProvidedProductss.Remove(providedProducts);
        }

        public static void Update(ProvidedProducts providedProducts)
        {
            var index = ProvidedProductss.FindIndex(p => p.Id == providedProducts.Id);
            if (index == -1)
                return;

            ProvidedProductss[index] = providedProducts;
        }
    }
}