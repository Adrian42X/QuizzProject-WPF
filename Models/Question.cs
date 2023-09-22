using System.Collections.Generic;

namespace QuizzProject.Models
{
    public class Question
    {
        public string? Text { get; set; }
        public string? Difficulty { get; set; }
        public List<Answer>? Answers { get; set; }
    }
}
