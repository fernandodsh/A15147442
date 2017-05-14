using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAdministradorDeEquipoRepository AdministradorDeEquipos { get;  }
        IAdministradorDeLineaRepository AdministradorDeLineas { get; }
        ICentroDeAtencionRepository CentroDeAtenciones { get; }
        IClienteRepository Clientes { get;  }
        IContratoRepository Contratos { get; }
        IDepartamentoRepository Departamentos { get; }
        IDireccionRepository Direcciones { get;  }
        IDistritoRepository Distritos { get; }
        IEquipoDeCelularRepository EquipoDeCelulares { get; }
        IEstadoDeEvaluacionRepository EstadoDeEvaluaciones { get; }
        IEvaluacionRepository Evaluaciones { get; }
        ILineaTelefonicaRepository LineaTelefonicas { get; }
        IPlanRepository Planes { get; }
        IProvinciaRepository Provincias { get; }
        ITipoDeEvaluacionRepository TipoDeEvaluaciones { get; }
        ITipoDeLineaRepository TipoDeLineas { get; }
        ITipoDePagoRepository TipoDePagos { get; }
        ITipoPlanRepository TipoPlanes { get; }
        ITipoTrabajadorRepository TipoTrabajadores { get; }
        ITrabajadorRepository Trabajadors { get; }
        IUbigeoRepository Ubigeos { get; }
        IVentaRepository Ventas { get; }


        int SaveChanges();




    }
}
