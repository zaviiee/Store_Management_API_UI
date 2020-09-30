
using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly UnityContainer container;

        
        public CurrencyRepository()
        {
            container = new UnityContainer();
        }

        public List<Currency> GetAll()
        {
            List<Currency> currencies = new List<Currency>();

            using (var db = new DataLayer.StoreDBEntities())
            {
                foreach (var c in db.GetAllCurrencies())
                {
                    Currency currency = new Currency();
                    currency.ID = c.ID;
                    currency.Currency_Name = c.Currency_Name;
                    currencies.Add(currency);
                }
            }

            return currencies;
        }

        public Currency GetByID(int ID)
        {
            throw new NotImplementedException();
        }
    }
}
