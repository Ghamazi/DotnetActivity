using AutoMapper;
using DotnetActivity.API.Services;
using DotnetActivity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DotnetActivity.Controllers
{
   
    [ApiController]
    [Route("api/Categories")]
    public class CategoryController : ControllerBase
    {
        private readonly IProductRes _ProductRes;
        private readonly IMapper _mapper;
        public CategoryController (IProductRes ProductRes,IMapper mapper)
        {
            _ProductRes = ProductRes ??
                throw new ArgumentNullException(nameof(ProductRes));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));

        }



        [HttpGet()]
        public ActionResult<IEnumerable<CategoryModel>> GetCategories()
        {
            var CategoryFromRepo = _ProductRes.GetCategorys();
            
           

            return Ok(_mapper.Map<IEnumerable<CategoryModel>>(CategoryFromRepo));
        }
        [HttpGet("{categoryid}",Name = "GetCategories")]
        public IActionResult GetCategory(Guid categoryid)
        {
            if (!_ProductRes.CategoryExists(categoryid)) { return NotFound(); };
            var CategoryFromRepo = _ProductRes.GetCategory(categoryid);

            return Ok(_mapper.Map<CategoryModel>(CategoryFromRepo));
        }
        [HttpPost]
        public ActionResult<CategoryModel> Createcategory( CategoryforCreation Cat)
        {
            var categorycreate = _mapper.Map<Category>(Cat);
              _ProductRes.AddCategory(categorycreate);
                _ProductRes.Save();
            var categorytoreturn=_mapper.Map<CategoryModel>(categorycreate);
            return CreatedAtRoute("GetCategories",
                new {CategoryID=categorytoreturn.Id},
                categorytoreturn);



        }


    }
}
