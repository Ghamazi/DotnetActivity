namespace DotnetActivity.Models
{
    public class CategoryModel
    {

        public Guid Id { get; set; }
      
        public string Name { get; set; }
        public ICollection<Products> ProductsUnderThisCategory { get; set; }
         = new List<Products>();

    }
}
