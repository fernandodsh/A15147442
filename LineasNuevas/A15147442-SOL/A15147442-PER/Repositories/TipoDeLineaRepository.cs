﻿using A15147442_ENT.IRepositories;
using A15147442_ENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{
    public class TipoDeLineaRepository : Repository<TipoDeLinea>, ITipoDeLineaRepository
    {
        private LineaNuevaDbContext _Context;

        public TipoDeLineaRepository(LineaNuevaDbContext context)
        {
            // TODO: Complete member initialization
             _Context = context;
        }

        private TipoDeLineaRepository()
        {

        }
    }
}