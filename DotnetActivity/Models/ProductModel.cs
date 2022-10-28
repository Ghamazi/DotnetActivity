namespace DotnetActivity.Models
{
    public class productmodel
    {
        public Guid Id { get; set; }
       
        public string Name { get; set; }
        public float price { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }

        public Guid CategoryId { get; set; }

    }
}
