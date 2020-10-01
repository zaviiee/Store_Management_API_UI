

using StoreManagementAPI.Models.DataLayer;
using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }
        public bool Add(Product obj)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID =  db.CreateProduct(
                    obj.Prod_Name, 
                    obj.Category_ID, 
                    obj.Unit_ID, 
                    obj.Price, 
                    obj.Currency_ID)
                    .FirstOrDefault();

                return returnID != null && returnID > 0; 
            }
        }

        public bool Delete(int ID)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID = db.DeleteProduct(ID).FirstOrDefault();

                return returnID != null && returnID > 0;
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (var db = new StoreDBEntities())
            {
                foreach (var p in db.GetAllProducts())
                {
                    Product product = new Product();
                    
                    product.ID = p.ID;
                    product.Prod_Name = p.Product_Name;
                    product.Price = p.Price;
                    product.Category_ID = p.Category_ID;
                    product.Category_Name = p.Category_Name;
                    product.Currency_ID = p.Currency_ID;
                    product.Currency_Name = p.Currency_Name;
                    product.Unit_ID = p.Unit_ID;
                    product.Unit_Name = p.Unit_Name;

                    products.Add(product);

                }
            }

            return products;

        }

        public Product GetByID(int ID)
        {

            Product product = new Product();
            using (var db = new StoreDBEntities())
            {
                var p = db.GetProduct(ID).FirstOrDefault();
                if (p != null)
                {
                    product.ID = p.ID;
                    product.Prod_Name = p.Product_Name;
                    product.Price = p.Price;
                    product.Category_ID = p.Category_ID;
                    product.Category_Name = p.Category_Name;
                    product.Currency_ID = p.Currency_ID;
                    product.Currency_Name = p.Currency_Name;
                    product.Unit_ID = p.Unit_ID;
                    product.Unit_Name = p.Unit_Name;

                }
            }

            return product;
        }

        public bool Update(Product obj)
        {
            using (var db = new StoreDBEntities())
            {
                var returnID = db.UpdateProduct(
                    obj.ID,
                    obj.Prod_Name,
                    obj.Category_ID,
                    obj.Unit_ID,
                    obj.Price,
                    obj.Currency_ID)
                    .FirstOrDefault();

                return returnID != null && returnID > 0;
            }
        }
    }
}
