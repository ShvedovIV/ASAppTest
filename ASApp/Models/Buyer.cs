using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASApp.Models
{
    public class Buyer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get; set;}

        [Required(ErrorMessage= "This field is required")]
        [MaxLength(40, ErrorMessage= "This field must contain between 2 and 40 characters")]
        [MinLength(2, ErrorMessage= "This field must contain between 2 and 40 characters")]
        public string Name {get; set;} = default!;
        public virtual ICollection<Sale> SaleIds {get; set;} = default!;  //TODO
         
    }
}