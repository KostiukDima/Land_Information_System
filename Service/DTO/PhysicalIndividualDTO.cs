using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    class PhysicalIndividualDTO
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Surname { get; set; }
        [DataMember] public string MiddleName { get; set; }
        [DataMember] public DateTime DateOfBirth { get; set; }
    }
}
