using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.ApiUtil;
using Web.Helper;

namespace Web.Factory
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        //private readonly IAppConfig _appCfg;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiUri),
          LazyThreadSafetyMode.ExecutionAndPublication);
        static ApiClientFactory()
        {
            //_appCfg = appCfg;
            apiUri = new Uri(URLStatic.APIClientURL);
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
