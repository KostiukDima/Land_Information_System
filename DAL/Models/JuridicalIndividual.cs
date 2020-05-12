﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class JuridicalIndividual
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string EDRPOUcode { get; set; }
        // Navigation properties
        public virtual ICollection<Owner> Owners { get; set; }


    }
}
