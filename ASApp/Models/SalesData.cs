using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASApp.Models
{
    public class SalesData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [ForeignKey("Product")]
        [Required]
        public int ProductId {get; set;}

        [Required]
        public int ProductQuantity {get; set;}

        [Required]
        public double ProductIdAmount {get; set;}

        [ForeignKey("Sale")]
        public int SaleId {get; set;}
        //public Sale Sale {get; set;}= default!;

        //public virtual ICollection<Sale> Sale {get; set;} = default!;
         
    }
}