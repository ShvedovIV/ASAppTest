using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{

    public static class SaleRep
    {
        static List<Sale> Sales { get; }
        static int nextId = 3;
        static SaleRep()
        {
            Sales = new List<Sale>
        {
            new Sale {Id = 1, /* Date = DateTime.Now, Time = DateTime.Now, */ SalesPointId = 1, BuyerId = 1, TotalAmount = 1000 },
            new Sale {Id = 2, /* Date = DateTime.Now, Time = DateTime.Now, */ SalesPointId = 2, BuyerId = null, TotalAmount = 1000}
        };

        }

        public static List<Sale> GetAll() => Sales;

        public static Sale? Get(int id) => Sales.FirstOrDefault(p => p.Id == id);

        public static int Add(Sale sale)
        {
            sale.Id = nextId++;
            Sales.Add(sale);
            return sale.Id;
        }

        public static void Delete(int id)
        {
            var sale = Get(id);
            if (sale is null)
                return;

            Sales.Remove(sale);
        }

        public static void Update(Sale sale)
        {
            var index = Sales.FindIndex(p => p.Id == sale.Id);
            if (index == -1)
                return;

            Sales[index] = sale;
        }
    }
}