using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class CheckBoxQuestion : Question
    {
        private List<Answer> possibleAnswers = new List<Answer>();

        public override string Text { get ; set; }

        public override List<Answer> SelectedAnswers { get; set; }

        public override IReadOnlyCollection<Answer> PossibleAnswers
        {
            get { return possibleAnswers.AsReadOnly(); }
            protected set { possibleAnswers = (List<Answer>)value; }
        }

        public override void AddAnswer(Answer answer)
        {
            if(!possibleAnswers.Any(ans=> ans.Equals(answer)))
                possibleAnswers.Add(answer);
        }

        public override bool GradeQuestion()
        {
            List<Answer> correctAnswers = possibleAnswers.Where(ans => ans.IsCorrectAnswer).ToList();
            return correctAnswers.SequenceEqual(SelectedAnswers);
        }

        public override void RemoveAnswer(Answer answer)
        {
            Answer answerToRemove = possibleAnswers.SingleOrDefault(ans => ans.Equals(answer));
            if(answerToRemove != null)
                possibleAnswers.Remove(answerToRemove);
        }

        public void SetCorrectAnswer(int answerId)
        {
            possibleAnswers.ForEach(ans => ans.IsCorrectAnswer = (ans.Id == answerId));
        }

        public void SetCorrectAnswers(List<int> answerIds)
        {
            answerIds.ForEach(id => SetCorrectAnswer(id));
        }
    }
}
