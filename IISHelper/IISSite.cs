using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISHelper
{
    public class IISSite
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Pool { get; set; }
        public string Cert { get; set; }
        public string State { get; set; }
        public int AppCount { get; set; }
        public int BindingCount { get; set; }
        public List<IISApplication> Applications { get; set; }
    }
}
