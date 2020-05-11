using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class StateRegistrationInfoDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string TechnicalDocumentation { get; set; }
        [DataMember] public string RegistrationAgency { get; set; }
        [DataMember] public DateTime DateTime { get; set; }
        [DataMember] public int LandLotId { get; set; }
    }
}
