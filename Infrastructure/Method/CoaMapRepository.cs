using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Core.Entity;
using Core.Interface;
using Newtonsoft.Json;

namespace Infrastructure.Method
{
    public class CoaMapRepository : IOContext<MapCoa>, ICoaMapRepository
    {
        public CoaMapRepository()
        { }
        public async Task<List<MapCoa>> GetListAsync(string location)
        {
            var jsonData = await File.ReadAllTextAsync(location);
            return JsonConvert.DeserializeObject<List<MapCoa>>(jsonData);
        }
    }
}
