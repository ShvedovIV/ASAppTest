using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASApp.Models
{
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Column(TypeName="date")]

        /* public DateTime Date {get; set;}

        [DataType(DataType.Time)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time {get; set;} */

        [ForeignKey("SalesPoint")]
        [Required]
        public int SalesPointId {get; set;}


        [ForeignKey("Buyer")]
        public int? BuyerId {get; set;}

        [Required]
        public double TotalAmount {get; set;}

        public SalesData[] SalesData {get; set;} = default!;

    }
}