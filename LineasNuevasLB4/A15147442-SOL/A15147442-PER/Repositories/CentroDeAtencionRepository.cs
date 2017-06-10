using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using A15147442_PER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class CentroDeAtencionRepository : Repository<CentroDeAtencion>, ICentroDeAtencionRepository
    {
        public CentroDeAtencionRepository(LineaNuevaDbContext context):base(context)
        {

        }


        //private readonly LineaNuevaDbContext _Context;

        //public CentroDeAtencionRepository(LineaNuevaDbContext context)
        //{
        //    // TODO: Complete member initialization
        //     _Context = context;
        //}

        //private CentroDeAtencionRepository()
        //{

        //}
    }
}
