using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Student
    {
        public Student()
        {
            Roster = new HashSet<Roster>();
            TestResults = new HashSet<TestResults>();
        }

        public int StudId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }

        public ICollection<Roster> Roster { get; set; }
        public ICollection<TestResults> TestResults { get; set; }
    }
}
