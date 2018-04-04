using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IISHelper
{
    public class IISBinding
    {
        public string Binding { get; set; }
        public string CertHash { get; set; }
        public string Name { get; set; }
        public string Protocol { get; set; }
    }
}
