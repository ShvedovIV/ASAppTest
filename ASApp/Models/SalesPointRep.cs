using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{
    public static class SalesPointRep
    {

        static List<SalesPoint> SalesPoints { get; }

      
        static int nextId = 3;
        static SalesPointRep()
        {
           
            SalesPoints = new List<SalesPoint>
            {
                new SalesPoint {Id = 1, Name = "Point1" },
                new SalesPoint {Id = 2, Name = "Point2"}
            };

        }

        public static List<SalesPoint> GetAll() => SalesPoints;

        public static SalesPoint? Get(int id) => SalesPoints.FirstOrDefault(p => p.Id == id);

        public static int Add(SalesPoint salesPoint)
        {
            salesPoint.Id = nextId++;
            SalesPoints.Add(salesPoint);
            return salesPoint.Id;
        }

        public static void Delete(int id)
        {
            var salesPoint = Get(id);
            if (salesPoint is null)
                return;

            SalesPoints.Remove(salesPoint);
        }

        public static void Update(SalesPoint salesPoint)
        {
            var index = SalesPoints.FindIndex(p => p.Id == salesPoint.Id);
            if (index == -1)
                return;

            SalesPoints[index] = salesPoint;
        }
    }
}