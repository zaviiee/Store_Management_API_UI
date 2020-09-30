

using StoreManagementAPI.Models.DataLayer;
using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IUnityContainer container;

        public CategoryRepository()
        {
            container = WebApiConfig.container;
        }

        public bool Add(Category obj)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID = db.CreateCategory(obj.Category_Name).FirstOrDefault();

                return returnID != null && returnID > 0;
            }
        }

        public bool Delete(int ID)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID = db.DeleteCategory(ID).FirstOrDefault();

                return returnID != null && returnID > 0;
            }
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();

            using (var db = new StoreDBEntities())
            {
                foreach (var c in db.GetAllCategories())
                {
                    Category category= new Category();
                    category.ID = c.ID;
                    category.Category_Name = c.Category_Name;
                    category.InUse = c.In_Use.Equals(1);
                    categories.Add(category);
                }
            }

            return categories;
        }

        public Category GetByID(int ID)
        {
            Category category = container.Resolve<Category>();

            using (var db = new StoreDBEntities())
            {
                var c = db.GetCategory(ID).FirstOrDefault();
                if (c != null)
                {
                    category.ID = c.ID;
                    category.Category_Name = c.Category_Name;
                    category.InUse = c.In_Use.Equals(1);
                }
            }

            return category;
        }

        public bool Update(Category obj)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID = db.UpdateCategory(obj.ID, obj.Category_Name).FirstOrDefault();

                return returnID != null && returnID > 0;
            }
        }
    }
}
