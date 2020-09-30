using StoreManagementAPI.Models;
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
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _repo = categoryRepository;
        }

        [HttpGet]
        public List<Category> GetAll()
        {
            return _repo.GetAll();
        }

        [HttpGet]
        public Category GetCategory(int ID)
        {
            return _repo.GetByID(ID);
        }

        [HttpGet]
        public bool Delete(int ID)
        {
            return _repo.Delete(ID);
        }


        [HttpPost]
        public bool Add(Category category)
        {
            return _repo.Add(category);
        }

        [HttpPost]
        public bool Update(Category category)
        {
            return _repo.Update(category);
        }
    }
}
