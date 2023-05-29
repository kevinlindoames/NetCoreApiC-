using NetCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.DATA.Repositories
{
    public interface ITrabajadorRepository
    {
        Task<IEnumerable<Trabajador>> GetAllTrabajadores();
        Task<Trabajador> GetDetails(int id);
        Task<bool> InsertTrabajador (Trabajador trabajador);
        Task<bool> UpdateTrabajador (Trabajador trabajador);
        Task<bool> DeleteTrabajador (Trabajador trabajador);

    }
}
