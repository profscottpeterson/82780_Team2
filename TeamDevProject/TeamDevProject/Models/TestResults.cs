using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class TestResults
    {
        public int TestResId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public string Answers { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
