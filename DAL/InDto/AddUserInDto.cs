using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.InDto
{
    public class AddUserInDto
    {
        public string Name { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
    }
}
