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
    /// <summary>
    /// Handle Operations on Category
    /// </summary>
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository _repo;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _repo = categoryRepository;
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns>List of Categories</returns>
        [HttpGet]
        public List<Category> GetAll()
        {
            return _repo.GetAll();
        }

        /// <summary>
        /// Get specific category
        /// </summary>
        /// <param name="ID">Category ID</param>
        /// <returns>Category Details</returns>
        [HttpGet]
        public Category GetCategory(int ID)
        {
            return _repo.GetByID(ID);
        }

        /// <summary>
        /// Delete specific category
        /// </summary>
        /// <param name="ID">Category ID</param>
        /// <returns>Whether deleted or not</returns>
        [HttpGet]
        public bool Delete(int ID)
        {
            return _repo.Delete(ID);
        }

        /// <summary>
        /// Add new category
        /// </summary>
        /// <param name="category">Category Object</param>
        /// <returns>Whether added or not</returns>
        [HttpPost]
        public bool Add(Category category)
        {
            return _repo.Add(category);
        }

        /// <summary>
        /// Update speicific category
        /// </summary>
        /// <param name="category">Category Object</param>
        /// <returns>Whether updated or not</returns>
        [HttpPost]
        public bool Update(Category category)
        {
            return _repo.Update(category);
        }
    }
}
