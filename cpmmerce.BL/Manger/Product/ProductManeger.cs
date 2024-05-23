using commerce.BL.Dtos.Product; 
using commerce.DAL.UnitOfWork; // Assuming this namespace contains the IUnitOfWork interface
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commerce.BL.Manger.Product // Assuming this namespace is correct
{
    public class ProductManeger : IProductManeger
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductManeger(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ProductDto> GetAll()
        {
            var products = _unitOfWork.productRepository.GetAll();
            if (products == null) return null;
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public IEnumerable<ProductDto>? GetByCategory(int IdCat) // Use nullable return type if method might return null
        {
            var products = _unitOfWork.productRepository.GetByCategory(IdCat);
            if (products == null) return null;
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public IEnumerable<ProductDto>? GetByName(string Name) // Implement the missing method
        {
            var products = _unitOfWork.productRepository.GetByName(Name); // Assuming GetByName exists in IProductRepository
            if (products == null) return null;
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Description = p.Description,
                Name = p.Name,
                Price = p.Price,
            });
        }

        public ProductDetailsDto? GetById(int id)
        {
            var product = _unitOfWork.productRepository.GetById(id);
            if (product == null) return null;

            return new ProductDetailsDto
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                CategoryName = product.category.Name, // Assuming product.category exists
                Color = product.Color,
                Size = product.Size
            };
        }
    }
}