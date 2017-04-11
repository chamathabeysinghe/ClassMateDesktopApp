using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMateDesktop.models
{
    class ClassRoom
    {
        public string _id { get; set; }
        public string name { get; set; }
        public string startTime { get; set; }
        public string endTime { get; set; }
        public string nextClassTime { get; set; }
        public string location { get; set; }
        public string isDiscoverable { get; set; }
        public List<Lecture> lectures { get; set; }
        
    }
}
