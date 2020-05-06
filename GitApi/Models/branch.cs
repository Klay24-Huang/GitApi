using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitApi.Models
{
    public class branch
    {
        public List<string> Branchs { get; set; }
        public DateTime LatestDateTime { get; set; }
    }
}
