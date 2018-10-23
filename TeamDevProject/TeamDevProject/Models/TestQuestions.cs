using System;
using System.Collections.Generic;

namespace TeamDevProject.Models
{
    public partial class TestQuestions
    {
        public int TestId { get; set; }
        public int QuestionId { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int? CorrectAnswer { get; set; }
        public string Question { get; set; }

        public Test Test { get; set; }
    }
}
