using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interface
{
    public interface ICoaMapRepository : IRepositoryAsync<MapCoa>
    {
        Task<List<MapCoa>> GetListAsync(string location);
    }
}
