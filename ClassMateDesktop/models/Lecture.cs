using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassMateDesktop.models
{
    class Lecture
    {

        public String lectureNumber { get; set; }
        public String lectureTitle { get; set; }
        public String lectureSummary { get; set; }
        public List<Question> questions { get; set; }
        public List<Feedback> feedbacks { get; set; }

    }
}
