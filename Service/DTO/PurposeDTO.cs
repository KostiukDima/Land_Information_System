using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    [DataContract]
    public class PurposeDTO
    {
       [DataMember] public int Id { get; set; }
       [DataMember] public string Code { get; set; }
       [DataMember] public string Name { get; set; }
        
       [DataMember] public string FullName 
       { 
            get { return Code + " " + Name; } 
            set { Name = value; Code = value; } 
       }

        


    }
}
