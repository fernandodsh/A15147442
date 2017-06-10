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
    public class DepartamentoRepository : Repository<Departamento>, IDepartamentoRepository
    {
        public DepartamentoRepository(LineaNuevaDbContext context):base(context)
        {

        }

        //private LineaNuevaDbContext _Context;

        //public DepartamentoRepository(LineaNuevaDbContext context)
        //{
        //    // TODO: Complete member initialization
        //     _Context = context;
        //}

        //private DepartamentoRepository()
        //{

        //}
    }
}
