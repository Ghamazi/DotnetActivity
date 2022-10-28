using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetActivity

{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Enter First NAme")]
        public string Name { get; set; }
        public float price { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
      
        [ForeignKey("CategoryId")]
        public Category Category{ get; set; }

        public Guid CategoryId { get; set; }
    





    }
}
