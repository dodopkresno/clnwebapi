using System;
using System.Collections.Generic;
using System.Text;
using Core.Entity;
using System.Threading.Tasks;

namespace Infrastructure.ApiUtil
{
    public partial class ApiClient
    {
        //Not Used for this project
        //public async Task<List<ReportModel>> GetReport()
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        "User/GetAllUsers"));
        //    return await GetAsync<List<ReportModel>>(requestUrl);
        //}
        public async Task<T1> PostReport<T1,T2>(T2 model)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                "invoice/Report1"));
            return await PostAsync<T1, T2>(requestUrl, model);
        }
    }
}
