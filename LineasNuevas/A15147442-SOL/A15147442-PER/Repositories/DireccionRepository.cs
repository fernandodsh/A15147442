using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class DireccionRepository : Repository<Direccion>, IDireccionRepository
    {
        private LineaNuevaDbContext _Context;

        public DireccionRepository(LineaNuevaDbContext context)
        {
            // TODO: Complete member initialization
            _Context = context;
        }

        private DireccionRepository()
        {

        }
    }
}
