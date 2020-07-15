using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helper;

namespace Web.Interface
{
    public interface IAppConfig
    {
        ApplicationConfig GetData();
        DummyUser Authenticate(string username, string password);
    }
}
