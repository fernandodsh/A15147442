using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class TipoPlanRepository : Repository<TipoPlan>, ITipoPlanRepository
    {
        private LineaNuevaDbContext _Context;

        public TipoPlanRepository(LineaNuevaDbContext context)
        {
            // TODO: Complete member initialization
            _Context = context;
        }

        private TipoPlanRepository()
        {

        }
    }
}
