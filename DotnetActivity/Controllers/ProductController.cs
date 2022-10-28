using AutoMapper;
using DotnetActivity.API.Services;
using DotnetActivity.Context;
using DotnetActivity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetActivity.Controllers
{
    [ApiController]
   // [Route("api/Category/{CategoryID}/Product")]
    [Route("api/Products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRes _ProductRes;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public ProductController(IProductRes ProductRes, IMapper mapper, DataContext context)
        {
            _ProductRes = ProductRes ??
                throw new ArgumentNullException(nameof(ProductRes));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
            _context = context ??
              throw new ArgumentNullException(nameof(context));
            
        }
        [HttpGet()]
        [HttpHead]

        public ActionResult<IEnumerable<productmodel>> GetProducts([FromQuery(Name = "categoryId")] Guid id)
        {
            if (id == Guid.Parse("00000000-0000-0000-0000-000000000000"))
            {
                var ProductFromRepo = _ProductRes.GetProducts();
                return Ok(_mapper.Map<IEnumerable<productmodel>>(ProductFromRepo));


            }
            else
            {
                var ProductFromRepo = _ProductRes.GetProducts(id);

                return Ok(_mapper.Map<IEnumerable<productmodel>>(ProductFromRepo));
            }
        }


        [HttpGet("{productiid}", Name = "GetProductforcategory")]
        public IActionResult GetProduct(Guid productiid)
        {
            if (_ProductRes.ProductsExistss(productiid)) { return NotFound(); }
            var ProductFromRepo = _ProductRes.GetProd(productiid);

            return Ok(_mapper.Map<productmodel>(ProductFromRepo));
        }
        //where product had a forignkey so categoryid must be passed in the post action
        //http://localhost:51044/api/Product/Category/CatgegoryId/Product
        [HttpPost("Categories/{CategoryID}/Products")]
        public ActionResult<productmodel> CreateProduct(Guid CategoryID, ProductForCreation productcr)
        {
            if (!_ProductRes.ProductsExistss(CategoryID))
            {
                return NotFound();
            }
            var ProductEntity = _mapper.Map<Products>(productcr);
            _ProductRes.AddProduct(CategoryID, ProductEntity);

            _ProductRes.Save();

            var ProductToReturn = _mapper.Map<productmodel>(ProductEntity);
            return Ok(ProductToReturn);
        }

        [HttpPut("{productid}")]
        public IActionResult UpdateProduct(
            Guid productid,
            ProductforUpdate updatecourse)
        {

            if (!_ProductRes.ProductsExists(productid))
            {

                return NotFound();

            }
            var productforcategory = _ProductRes.GetProduct( productid);
            if (productforcategory == null)
            {
                return NotFound();

            }
            _mapper.Map(updatecourse, productforcategory);
            _ProductRes.UpdateProduct(productforcategory);
            _ProductRes.Save();
            return Ok(productforcategory);
        }
        [HttpDelete("{productid}")]
        public ActionResult DeleteProduct(Guid productid)
        {
          

            var productrepo = _ProductRes.GetProduct(productid);

            if (productrepo == null)
            {
                return NotFound();
            }

            _ProductRes.DeleteProduct(productrepo);
            _ProductRes.Save();

            return NoContent();
        }
        //public IActionResult UpdateProduct(Guid categoryid,
        //    Guid productid,
        //    ProductforUpdate updatecourse)
        //{

        //    if(!_ProductRes.ProductsExists(categoryid))
        //    {

        //        return NotFound();

        //    }
        //        var productforcategory=_ProductRes.GetProduct(categoryid,productid);
        //    if(productforcategory == null)
        //    {
        //        return NotFound();

        //    }
        //    _mapper.Map(updatecourse, productforcategory);
        //    _ProductRes.UpdateProduct(productforcategory);
        //    _ProductRes.Save();
        //    return NoContent();



        //}

        //[HttpPost]
        //public ActionResult<productmodel> CreateProduct(ProductForCreation product)
        //{
        //    var ProductEntity = _mapper.Map<Products>(product);
        //    _ProductRes.AddProduct(ProductEntity);
        //    _ProductRes.Save();
        //    var ProductToReturn = _mapper.Map<productmodel>(ProductEntity);
        //    return CreatedAtRoute("GetProductforcategory",
        //        new { Productid = ProductToReturn.Id },
        //        ProductToReturn);




        //}
    }
}



