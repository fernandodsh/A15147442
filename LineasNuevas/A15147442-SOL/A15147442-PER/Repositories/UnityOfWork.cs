using System;
using A15147442_ENT.IRepositories;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_PER.Repositories
{

    public class UnityOfWork : IUnityOfWork
    {

        private readonly LineaNuevaDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();


        public IAdministradorDeEquipoRepository AdministradorDeEquipos { get; private set; }
        public IAdministradorDeLineaRepository AdministradorDeLineas { get; private set; }
        public ICentroDeAtencionRepository CentroDeAtenciones { get; private set; }
        public IClienteRepository Clientes { get; private set; }
        public IContratoRepository Contratos { get; private set; }
        public IDepartamentoRepository Departamentos { get; private set; }
        public IDireccionRepository Direcciones { get; private set; }
        public IDistritoRepository Distritos { get; private set; }
        public IEquipoDeCelularRepository EquipoDeCelulares { get; private set; }
        public IEstadoDeEvaluacionRepository EstadoDeEvaluaciones { get; private set; }
        public IEvaluacionRepository Evaluaciones { get; private set; }
        public ILineaTelefonicaRepository LineaTelefonicas { get; private set; }
        public IPlanRepository Planes { get; private set; }
        public IProvinciaRepository Provincias { get; private set; }
        public ITipoDeEvaluacionRepository TipoDeEvaluaciones { get; private set; }
        public ITipoDeLineaRepository TipoDeLineas { get; private set; }
        public ITipoDePagoRepository TipoDePagos { get; private set; }
        public ITipoPlanRepository TipoPlanes { get; private set; }
        public ITipoTrabajadorRepository TipoTrabajadores { get; private set; }
        public ITrabajadorRepository Trabajadors { get; private set; }
        public IUbigeoRepository Ubigeos { get; private set; }
        public IVentaRepository Ventas { get; private set; }



        private UnityOfWork()
        {
            _Context = new LineaNuevaDbContext();
            AdministradorDeEquipos = new AdministradorDeEquipoRepository(_Context);
            AdministradorDeLineas  = new AdministradorDeLineaRepository(_Context);
            CentroDeAtenciones     = new CentroDeAtencionRepository(_Context);
            Clientes               = new ClienteRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Direcciones = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            EquipoDeCelulares = new EquipoDeCelularRepository(_Context);
            EstadoDeEvaluaciones = new EstadoDeEvaluacionRepository(_Context);
            Evaluaciones = new EvaluacionRepository(_Context);
            LineaTelefonicas = new LineaTelefonicaRepository(_Context);
            Planes = new PlanRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            TipoDeEvaluaciones = new TipoDeEvaluacionRepository(_Context);
            TipoDeLineas = new TipoDeLineaRepository(_Context);
            TipoDePagos = new TipoDePagoRepository(_Context);
            TipoPlanes = new TipoPlanRepository(_Context);
            TipoTrabajadores = new TipoTrabajadorRepository(_Context);
            Trabajadors = new TrabajadorRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Ventas = new VentaRepository(_Context);
        }


        public static UnityOfWork Instance
        {
            get 
            {
               lock (_Lock)
               {
                   if (_Instance == null)
                       _Instance = new UnityOfWork();
               }

                return _Instance;
            }
        }



        public int  SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}
