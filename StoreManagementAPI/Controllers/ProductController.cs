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
    public class ProductController : ApiController
    {
        private readonly IProductRepository _repo;
        public ProductController(IProductRepository productRepository)
        {
            _repo = productRepository;
        }

        [HttpGet]
        public List<Product> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        public Product GetProduct(int ID)
        {
            return _repo.GetByID(ID);
        }

        [HttpGet]
        public bool Delete(int ID)
        {
            return _repo.Delete(ID);
        }


        [HttpPost]
        public bool Add(Product product)
        {
            ;
            return _repo.Add(product);
        }

        [HttpPost]
        public bool Update(Product product)
        {
            return _repo.Update(product);
        }
    }
}
