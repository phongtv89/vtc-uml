using System.Collections.Generic;
using ClothingShopApp.DAL;
using ClothingShopApp.DTO;

namespace ClothingShopApp.BL
{
    public class ProductBL
    {
        private readonly ProductDAL _productDAL;

        public ProductBL(ProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        public List<Product> GetAllProducts() => _productDAL.GetAllProducts();

        public Product GetProductById(int id) => _productDAL.GetProductById(id);

        public void AddProduct(Product product) => _productDAL.AddProduct(product);

        public void UpdateProduct(Product product) => _productDAL.UpdateProduct(product);

        public void DeleteProduct(int id) => _productDAL.DeleteProduct(id);
    }
}