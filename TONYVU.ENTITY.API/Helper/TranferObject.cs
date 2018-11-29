using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Core
{
    [Serializable]
    [DataContract]
    public class TranferObject<T> where T : new()
    {
        public TranferObject()
        {
            ExtendData = new List<T>();
            Data = Activator.CreateInstance<T>();
        }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public List<T> ExtendData { get; set; }

        [DataMember]
        public bool Status { get; set; }

    }

    [Serializable]
    [DataContract]
    public class TranferObject : TranferObject<object>
    {
        
    }
}
