using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamDevProject.Models
{
    public partial class TestResults
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TestResId { get; set; }
        public int TestId { get; set; }
        public int Score { get; set; }
        public string Answers { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
