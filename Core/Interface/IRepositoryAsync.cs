using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;

namespace Core.Interface
{
    public interface IRepositoryAsync<T> where T : class, IEntity
    {
        Task<List<T>> GetDataIOAsync(string location);
    }
}
