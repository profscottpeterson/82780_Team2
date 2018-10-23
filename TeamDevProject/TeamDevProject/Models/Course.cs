using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Course
    {
        public Course()
        {
            Instructor = new HashSet<Instructor>();
            Roster = new HashSet<Roster>();
            Test = new HashSet<Test>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }

        public ICollection<Instructor> Instructor { get; set; }
        public ICollection<Roster> Roster { get; set; }
        public ICollection<Test> Test { get; set; }
    }
}
