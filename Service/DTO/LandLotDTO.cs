using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class LandLotDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string CadastralNumber { get; set; }
        [DataMember] public double Area { get; set; }
        [DataMember] public int LocationId { get; set; }
        [DataMember] public int PurposeId { get; set; }
        [DataMember] public int LandCategoryId { get; set; }
        [DataMember] public int ExploitationTypeId { get; set; }
        [DataMember] public int OwnershipTypeId { get; set; }
        [DataMember] public int MonetaryValuationId { get; set; }
        [DataMember] public int StateRegistrationInfoId { get; set; }
        [DataMember] public int SoilId { get; set; }
        [DataMember] public int OwnerId { get; set; }
    }
}
