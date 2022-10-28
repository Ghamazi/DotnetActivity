using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotnetActivity
{
    public class Category
    {
        [Key]
     
        public Guid Id { get; set; }
      //  public int CategoryID { get; set; }
        public string Name { get; set; }
        public ICollection<Products> ProductsUnderThisCategory { get; set; }
          = new List<Products>();




    }
}
