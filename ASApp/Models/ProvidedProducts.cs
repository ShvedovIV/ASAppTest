using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASApp.Models
{
    public class ProvidedProducts
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [ForeignKey("Product")]
        [Required]
        public int ProductId {get; set;}

        public int ProductQuantity {get; set;}

        [ForeignKey("SalesPoint")]
        public int SalesPointId {get; set;}

         
    }
}