using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Web.Helper
{
    public class DummyUser
    {
        //need for claimidentity
        public int Id { get; set; }
        public string uname { get; set; }
        [JsonIgnore]
        public string pass { get; set; }
        public string token { get; set; }

        public DummyUser(int Id, string uname, string pass, string token)
        {
            this.Id = Id;
            this.uname = uname;
            this.pass = pass;
            this.token = token;
        }
    }
}
