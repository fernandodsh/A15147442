using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        private LineaNuevaDbContext _Context;

        public PlanRepository(LineaNuevaDbContext context)
        {
            // TODO: Complete member initialization
             _Context = context;
        }

        private PlanRepository()
        {

        }
    }
}
