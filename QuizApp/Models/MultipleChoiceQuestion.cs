using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class MultipleChoiceQuestion : Question
    {
        private List<Answer> possibleAnswers = new List<Answer>();
        public override string Text { get; set; }

        public override IReadOnlyCollection<Answer> PossibleAnswers
        {
            get { return possibleAnswers.AsReadOnly(); }
            protected set { possibleAnswers = (List<Answer>)value; }
        }

        public override void AddAnswer(Answer answer)
        {
            if (possibleAnswers.Any(ans => ans.IsCorrectAnswer) && answer.IsCorrectAnswer)
                throw new Exception("This question can have only one correct answer selected.");

            possibleAnswers.Add(answer);
        }

        public override bool GradeQuestion(List<Answer> selectedAnswers)
        {
            Answer correctAnswer = possibleAnswers.Single(ans => ans.IsCorrectAnswer);
            return selectedAnswers.Single().Equals(correctAnswer);
        }

        public override void RemoveAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }
    }
}
