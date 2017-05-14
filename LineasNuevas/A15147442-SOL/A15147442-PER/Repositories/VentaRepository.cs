using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        private readonly LineaNuevaDbContext _Context;

        public VentaRepository(LineaNuevaDbContext context)
        {
            // TODO: Complete member initialization
           _Context = context;
        }
        public IEnumerable<Venta> GetVentasWithCentroDeAtencions(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
