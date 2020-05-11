using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class ChangingDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Description { get; set; }
        [DataMember] public int LandLotId { get; set; }
    }
}
