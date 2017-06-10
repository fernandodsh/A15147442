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
    public class ContratoRepository : Repository<Contrato>, IContratoRepository 
    {

        public ContratoRepository(LineaNuevaDbContext context):base(context)
        {

        }

        //private LineaNuevaDbContext _Context;

        //public ContratoRepository(LineaNuevaDbContext context)
        //{
        //    // TODO: Complete member initialization
        //    _Context = context;
        //}

        //private ContratoRepository()
        //{

        //}
    }
}
