
using StoreManagementAPI.Models.DataLayer;
using StoreSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity;

namespace StoreManagementAPI.Models.BusinessLayer
{
    public class UnitRepository : IUnitRepository
    {
        private readonly IUnityContainer container;

        public UnitRepository()
        {
            container = WebApiConfig.container;
        }
        public List<Unit> GetAll()
        {
            List<Unit> units = new List<Unit>();
            using (var db = new StoreDBEntities())
            {
                foreach (var u in db.GetAllUnits())
                {
                    var unit = new Unit();
                    unit.ID = u.ID;
                    unit.Unit_Name = u.Unit_Name;
                    units.Add(unit);
                }
            }
            return units;
        }

        public Unit GetByID(int ID)
        {
            throw new NotImplementedException();
        }

    }
}
