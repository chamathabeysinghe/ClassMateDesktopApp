using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMateDesktop.models
{
    class Question
    {

        public string _id { get; set; }
        public string details { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public List<Answer> answers;

    }
}
