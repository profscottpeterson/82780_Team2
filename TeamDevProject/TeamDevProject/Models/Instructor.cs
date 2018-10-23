using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Instructor
    {
        public int InstructorId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int? CourseId { get; set; }

        public Course Course { get; set; }
    }
}
