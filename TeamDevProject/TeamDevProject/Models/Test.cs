using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class Test
    {
        public Test()
        {
            TestQuestions = new HashSet<TestQuestions>();
        }

        public int TestId { get; set; }
        public string Subject { get; set; }
        public int CourseId { get; set; }

        public Course Course { get; set; }
        public ICollection<TestQuestions> TestQuestions { get; set; }
    }
}
