using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A15147442_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
     
        ICentroDeAtencionRepository CentroDeAtenciones { get; }
        IClienteRepository Clientes { get;  }
        IContratoRepository Contratos { get; }
        IDepartamentoRepository Departamentos { get; }
        IDireccionRepository Direcciones { get;  }
        IDistritoRepository Distritos { get; }
        IEquipoDeCelularRepository EquipoDeCelulares { get; }  
        IEvaluacionRepository Evaluaciones { get; }
        ILineaTelefonicaRepository LineaTelefonicas { get; }
        IPlanRepository Planes { get; }
        IProvinciaRepository Provincias { get; }
        ITrabajadorRepository Trabajadores { get; }
        IVentaRepository Ventas { get; }


        int SaveChanges();

        void StateModified(object entity);




    }
}
