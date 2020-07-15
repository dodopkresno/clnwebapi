using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Entity
{
    [DataContract]
    public class MessageIncMulti<T>
    {
        [DataMember(Name = "status")]
        public bool status { get; set; }
        [DataMember(Name = "message")]
        public string message { get; set; }
        [DataMember(Name = "data")]
        private List<T> _data = new List<T>();
        public List<T> data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
}
