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
    public class EvaluacionRepository : Repository<Evaluacion>, IEvaluacionRepository
    {

        private readonly LineaNuevaDbContext _Context;
        private EvaluacionRepository()
        {

        }

        public EvaluacionRepository(LineaNuevaDbContext context)
        {
            _Context = context;
        }

        public IEnumerable<Evaluacion> GetEvaluacionsWithCentroDeAtencions(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
