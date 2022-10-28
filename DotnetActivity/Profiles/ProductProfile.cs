using AutoMapper;

namespace DotnetActivity.Profiles
{
    public class ProductProfile:Profile
    {
       public ProductProfile()
        {

            CreateMap<Products, Models.productmodel>();
            CreateMap<Models.ProductForCreation,Products>();
            CreateMap<Models.ProductforUpdate, Products>();


        }
    }
}
