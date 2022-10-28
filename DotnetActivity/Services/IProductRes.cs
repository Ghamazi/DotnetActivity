
using System;
using System.Collections.Generic;

namespace DotnetActivity.API.Services
{
    public interface IProductRes
    {
        IEnumerable<Products> GetProducts();

        public Products GetProduct(Guid ProductId);

        IEnumerable<Products> GetProducts(Guid CategoryId);
        Products GetProduct(Guid CategoryId, Guid ProductId);
        void AddProduct(Guid CategoryId, Products Product);
        void AddProduct( Products Product);

        void UpdateProduct(Products Product);
        void DeleteProduct(Products Product);
        IEnumerable<Category> GetCategorys();
        Category GetCategory(Guid CategoryId);
        Products GetProd(Guid ProductId);
        IEnumerable<Category> GetCategorys(IEnumerable<Guid> CategoryIds);
        void AddCategory(Category Category);
        void DeleteCategory(Category Category);
        void UpdateCategory(Category Category);
        bool CategoryExists(Guid CategoryId);
        bool ProductsExists(Guid Peoductid);
        public bool ProductsExistss(Guid Peoductid);


        bool Save();
    }
}
