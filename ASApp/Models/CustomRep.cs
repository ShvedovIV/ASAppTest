using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{

    public static class CustomRep
    {
        static List<Sale> Sales { get; } = default!;
        static int nextId = 3;

        public static List<Sale> GetAll() => Sales;

        public static Sale? Get(int id) => Sales.FirstOrDefault(p => p.Id == id);

        public static void Add(Sale sale)
        {
            sale.Id = nextId++;
            Sales.Add(sale);
        }

    }
}