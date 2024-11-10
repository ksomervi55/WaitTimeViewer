using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitTimeViewer.Models
{
    public class Land
    {
        int id { get; set; }
        public IEnumerable<Ride> rides { get; set; }
    }
}
