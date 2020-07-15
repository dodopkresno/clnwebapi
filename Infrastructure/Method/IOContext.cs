using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Interface;
using Newtonsoft.Json;

namespace Infrastructure.Method
{
    public class IOContext<TEntity> : IRepositoryAsync<TEntity>
        where TEntity : class, IEntity
    {
        public IOContext()
        { 
        }
        public async Task<List<TEntity>> GetDataIOAsync(string location)
        {
            var jsonData = await File.ReadAllTextAsync(location);
            return JsonConvert.DeserializeObject<List<TEntity>>(jsonData);
        }
    }
}
