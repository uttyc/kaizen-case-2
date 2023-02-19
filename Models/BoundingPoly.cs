using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen_Case2.Models
{
    public class BoundingPoly
    {
        public List<Vertex> vertices { get; set; }
        public Vertex avg { get; set; }
    }
}
