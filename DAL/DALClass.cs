using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALClass
    {
        LandSystemDBModel context;

        public DALClass()
        {
            context = new LandSystemDBModel(); 
        }
    }
}
