using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{

    public static class SalesDataRep
    {
        static List<SalesData> SalesDatas { get; }
        static int nextId = 3;
        static SalesDataRep()
        {
            SalesDatas = new List<SalesData>
        {
            new SalesData {Id = 1, ProductId = 1, ProductQuantity = 10, ProductIdAmount = 3300},
            new SalesData {Id = 2, ProductId = 2, ProductQuantity = 10, ProductIdAmount = 2600}
        };

        }

        public static List<SalesData> GetAll() => SalesDatas;

        public static SalesData? Get(int id) => SalesDatas.FirstOrDefault(p => p.Id == id);

        public static void Add(SalesData salesData)
        {
            salesData.Id = nextId++;
            SalesDatas.Add(salesData);
        }

        public static void Delete(int id)
        {
            var salesData = Get(id);
            if (salesData is null)
                return;

            SalesDatas.Remove(salesData);
        }

        public static void Update(SalesData salesData)
        {
            var index = SalesDatas.FindIndex(p => p.Id == salesData.Id);
            if (index == -1)
                return;

            SalesDatas[index] = salesData;
        }
    }
}