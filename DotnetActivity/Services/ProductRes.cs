using DotnetActivity.API.Services;
using DotnetActivity.Context;


using System;
using System.Collections.Generic;
using System.Linq;
namespace DotnetActivity.Services
{
    public class ProductRes: IProductRes , IDisposable
    {
        private readonly DataContext _context;
        public ProductRes(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddCategory(Category Category)
        {
            if (Category == null)
            {
                throw new ArgumentNullException(nameof(Category));
            }

            // the repository fills the id (instead of using identity columns)
            Category.Id = Guid.NewGuid();

            foreach (var product in Category.ProductsUnderThisCategory)
            {
                Category.Id = Guid.NewGuid();
            }

            _context.Categories.Add(Category);
        }
        public void AddProduct(Products Product)
        {
            if (Product == null)
            {
                throw new ArgumentNullException(nameof(Product));
            }

            // the repository fills the id (instead of using identity columns)
            
             Product.Id = Guid.NewGuid(); 
             Product.CategoryId=Guid.NewGuid();

            _context.Product.Add(Product);
        }

        public void AddProduct(Guid CategoryId, Products Product)
        {
            if (CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CategoryId));
            }

            if (Product == null)
            {
                throw new ArgumentNullException(nameof(Product));
            }
            // always set the AuthorId to the passed-in authorId
            Product.CategoryId = CategoryId;
            _context.Product.Add(Product);
        }

       

        public bool CategoryExists(Guid CategoryId)
        {
            if (CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CategoryId));
            }

            return _context.Categories.Any(a => a.Id == CategoryId);
        }

        public void DeleteCategory(Category Category)
        {
            if (Category == null)
            {
                throw new ArgumentNullException(nameof(Category));
            }

            _context.Categories.Remove(Category);
        }

        public void DeleteProduct(Products Product)
        {
            _context.Product.Remove(Product); ;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Category GetCategory(Guid CategoryId)
        {
            if (CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CategoryId));
            }

            return _context.Categories.FirstOrDefault(a => a.Id == CategoryId);
        }

        public IEnumerable<Category> GetCategorys()
        {
            return _context.Categories.ToList<Category>();
        }

        public IEnumerable<Category> GetCategorys(IEnumerable<Guid> CategoryIds)
        {
            if (CategoryIds == null)
            {
                throw new ArgumentNullException(nameof(CategoryIds));
            }

            return _context.Categories.Where(a => CategoryIds.Contains(a.Id))
                .OrderBy(a => a.Name)
                
                .ToList();
        }

        public Products GetProd(Guid ProductId)
        {
            if (ProductId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProductId));
            }

            return _context.Product.FirstOrDefault(a => a.Id == ProductId);
        }
        public Products GetProduct(Guid ProductId)
        {
         

            if (ProductId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProductId));
            }

            return _context.Product
              .Where(c => c.Id == ProductId).FirstOrDefault();
        }

        public Products GetProduct(Guid CategoryId, Guid ProductId)
        {
            if (CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CategoryId));
            }

            if (ProductId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ProductId));
            }

            return _context.Product
              .Where(c => c.CategoryId == CategoryId && c.Id == ProductId).FirstOrDefault();
        }

        public IEnumerable<Products> Getproducts(Guid CategoryId)
        {
            if (CategoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(CategoryId));
            }

            return _context.Product
                        .Where(c => c.CategoryId == CategoryId)
                        .OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<Products> GetProducts()
        {
            return _context.Product.ToList<Products>();
            // string x = CategoryId.ToString();
            //x = x.Trim();
            //return _context.Product.Where(a => a.Id == CategoryId).ToList();
        }

        public IEnumerable<Products> GetProducts(Guid CategoryId)
        {
        
            return _context.Product.Where(a => a.CategoryId == CategoryId).ToList(); 
        }
        public bool ProductsExistss(Guid Peoductid)
        {
            if (Peoductid == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Peoductid));
            }

            return _context.Categories.Any(a => a.Id == Peoductid);
        }

        public bool ProductsExists(Guid Peoductid)
        {
            if (Peoductid == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(Peoductid));
            }

            return _context.Product.Any(a => a.Id == Peoductid);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCategory(Category Category)
        {
            //throw new NotImplementedException();
        }

        public void UpdateProduct(Products Product)
        {
            //throw new NotImplementedException();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

       

    }
}
