using StoreManagementAPI.Models.BusinessLayer;
using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace StoreManagementAPI.Controllers
{
    /// <summary>
    /// Handle Operations on Product
    /// </summary>
    public class ProductController : ApiController
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository productRepository)
        {
            _repo = productRepository;
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of Products</returns>
        [HttpGet]
        public List<Product> GetAll()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Get specific product
        /// </summary>
        /// <param name="ID">Product ID</param>
        /// <returns>Product Details</returns>
        [HttpGet]
        public Product GetProduct(int ID)
        {
            return _repo.GetByID(ID);
        }

        /// <summary>
        /// Delete specific product
        /// </summary>
        /// <param name="ID">Product ID</param>
        /// <returns>Whether deleted or not</returns>
        [HttpGet]
        public bool Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">Product Object</param>
        /// <returns>Whether added or not</returns>
        [HttpPost]
        public bool Add(Product product)
        {
            ;
            return _repo.Add(product);
        }

        /// <summary>
        /// Update specific product
        /// </summary>
        /// <param name="product">Product Object</param>
        /// <returns>Whether updated or not</returns>
        [HttpPost]
        public bool Update(Product product)
        {
            return _repo.Update(product);
        }
    }
}
