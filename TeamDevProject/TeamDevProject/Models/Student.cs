using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Student
    {
        public Student(string fname, string lname, string userId)
        {
            this.Fname = fname;
            this.Lname = lname;
            this.UserId = userId;
            Roster = new HashSet<Roster>();
            TestResults = new HashSet<TestResults>();
        }

        public int StudId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<Roster> Roster { get; set; }
        public ICollection<TestResults> TestResults { get; set; }
    }
}
