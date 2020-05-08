﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class OwnershipType
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        // Navigation properties
        public virtual ICollection<LandLot> LandLots { get; set; }

    }
}
