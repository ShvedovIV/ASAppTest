using System.Collections.Generic;
using System.Linq;

namespace ASApp.Models
{

    public static class BuyerRep
    {
        static List<Buyer> Buyers { get; }
        static int nextId = 3;
        static BuyerRep()
        {
            Buyers = new List<Buyer>
        {
            new Buyer {Id = 1, Name = "Ivan" },
            new Buyer {Id = 2, Name = "Misha" }
        };

        }

        public static List<Buyer> GetAll() => Buyers;

        public static Buyer? Get(int id) => Buyers.FirstOrDefault(p => p.Id == id);

        public static int Add(Buyer buyer)
        {
            buyer.Id = nextId++;
            Buyers.Add(buyer);
            return buyer.Id;
        }

        public static void Delete(int id)
        {
            var buyer = Get(id);
            if (buyer is null)
                return;

            Buyers.Remove(buyer);
        }

        public static void Update(Buyer buyer)
        {
            var index = Buyers.FindIndex(p => p.Id == buyer.Id);
            if (index == -1)
                return;

            Buyers[index] = buyer;
        }
    }
}