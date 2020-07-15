using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Core.Entity
{
    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "IsSuccess")]
        public bool IsSuccess { get; set; }
        [DataMember(Name = "ReturnMessage")]
        public string ReturnMessage { get; set; }
        [DataMember(Name = "Data")]
        public T data { get; set; }
    }
}
