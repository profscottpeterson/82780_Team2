using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Roster
    {
        public int CourseId { get; set; }
        public int StudId { get; set; }

        public Course Course { get; set; }
        public Student Stud { get; set; }
    }
}
