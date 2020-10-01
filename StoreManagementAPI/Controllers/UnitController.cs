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
    /// Handle Operations on Unit
    /// </summary>
    public class UnitController : ApiController
    {
        private readonly IUnitRepository _repo;
        public UnitController(IUnitRepository unitRepository)
        {
            _repo = unitRepository;
        }

        /// <summary>
        /// Get all Units
        /// </summary>
        /// <returns>List of units</returns>
        public List<Unit> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
