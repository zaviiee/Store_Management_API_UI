using StoreManagementAPI.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagementAPI.Controllers
{
    /// <summary>
    /// Handle Operations on Currency
    /// </summary>
    public class CurrencyController : ApiController
    {
        private readonly ICurrencyRepository _repo;
        public CurrencyController(ICurrencyRepository currencyRepository)
        {
            _repo = currencyRepository;
        }

        /// <summary>
        /// Get all currencies
        /// </summary>
        /// <returns>List of currencies</returns>
        public List<Currency> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
