using System;
using A15147442_ENT.IRepositories;
using A15147442_PER.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{

    public class UnityOfWork:IUnityOfWork
    {

        private readonly LineaNuevaDbContext _Context;

        //private static UnityOfWork _Instance;
        //private static readonly object _Lock = new object();

        public ICentroDeAtencionRepository CentroDeAtenciones { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IContratoRepository Contratos { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDireccionRepository Direcciones { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEquipoDeCelularRepository EquipoDeCelulares { get; private set; }

        public IEvaluacionRepository Evaluaciones { get; private set; }
        public ILineaTelefonicaRepository LineaTelefonicas { get; private set; }
        public IPlanRepository Planes { get; private set; }
        public IProvinciaRepository Provincias { get; private set; }
    
        public ITrabajadorRepository Trabajadores { get; private set; }

        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {

        }

        public UnityOfWork(LineaNuevaDbContext context)
        {
            _Context = context;

            CentroDeAtenciones     = new CentroDeAtencionRepository(context);
            Clientes               = new ClienteRepository(context);
            Contratos = new ContratoRepository(context);
            Departamentos = new DepartamentoRepository(context);
            Direcciones = new DireccionRepository(context);
            Distritos = new DistritoRepository(context);
            EquipoDeCelulares = new EquipoDeCelularRepository(context);
         
            Evaluaciones = new EvaluacionRepository(context);
            LineaTelefonicas = new LineaTelefonicaRepository(context);
            Planes = new PlanRepository(context);
            Provincias = new ProvinciaRepository(context);
          
            Trabajadores = new TrabajadorRepository(context);

            Ventas = new VentaRepository(context);
        }


        //public static UnityOfWork Instance
        //{
        //    get 
        //    {
        //       lock (_Lock)
        //       {
        //           if (_Instance == null)
        //               _Instance = new UnityOfWork();
        //       }

        //        return _Instance;
        //    }
        //}



        public int  SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

    }
}
