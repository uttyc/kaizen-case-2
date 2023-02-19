using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaizen_Case2.Models
{
    public class Line
    {
        public string? locale { get; set; }
        public string? description { get; set; }
        public BoundingPoly? boundingPoly { get; set; }
    }
}
