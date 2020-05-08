using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class LocationDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Region { get; set; }
        [DataMember] public string District { get; set; }
        [DataMember] public string Settlement { get; set; }
        [DataMember] public string Street { get; set; }
        [DataMember] public int LandLotId { get; set; }
    }
}
