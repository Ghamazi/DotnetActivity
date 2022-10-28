using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DotnetActivity.Profiles;
namespace DotnetActivity.Profiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, Models.CategoryModel>();
            CreateMap<Models.CategoryforCreation, Category>();





        }
    }
}
