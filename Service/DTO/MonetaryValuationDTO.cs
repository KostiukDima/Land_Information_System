using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class MonetaryValuationDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public double Km { get; set; }
        [DataMember] public double Kf { get; set; }
        [DataMember] public decimal Value { get; set; }
        [DataMember] public int LandLotId { get; set; }
    }
}
