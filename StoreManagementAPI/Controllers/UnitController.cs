using StoreManagementAPI.Models.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManagementAPI.Controllers
{
    public class UnitController : ApiController
    {
        private readonly IUnitRepository _repo;
        public UnitController(IUnitRepository unitRepository)
        {
            _repo = unitRepository;
        }

        public List<Unit> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
