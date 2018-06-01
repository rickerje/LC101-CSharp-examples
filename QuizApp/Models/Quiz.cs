using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public double PercentCorrect { get { return NumberCorrect / NumberPossible * 100; } } //TODO: Verify there isn't an error due to int casting
        public int NumberPossible { get { return Questions.Count; } }
        public int NumberCorrect { get; private set; }

        public Quiz()
        {
            Questions = new List<Question>();
        }

        public void GradeQuiz()
        {
            foreach (Question question in Questions)
                if (question.GradeQuestion())
                    NumberCorrect++;
        }
    }
}
