using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaitTimeViewer.Models
{
    public class ParkGroup
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public IEnumerable<Park> parks = new List<Park>();
    }
}
