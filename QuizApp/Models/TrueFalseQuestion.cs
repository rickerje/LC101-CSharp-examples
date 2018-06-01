using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class TrueFalseQuestion : Question
    {
        private List<Answer> possibleAnswers = new List<Answer>();

        public override string Text { get; set; }

        public override List<Answer> SelectedAnswers { get; set; }

        public override IReadOnlyCollection<Answer> PossibleAnswers
        {
            get { return possibleAnswers.AsReadOnly(); }
            protected set { possibleAnswers = (List<Answer>)value; }
        }

        protected TrueFalseQuestion()
        {
            possibleAnswers.Add(new Answer { Text = "True" });
            possibleAnswers.Add(new Answer { Text = "False" });
        }

        public TrueFalseQuestion(string text, bool answer) : this()
        {            
            this.Text = text;
            possibleAnswers.Where(ans => ans.Text.ToLower() == answer.ToString().ToLower());
        }

        public override void AddAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public override void RemoveAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public void SetCorrectAnswer(int answerId)
        {
            possibleAnswers.ForEach(ans => ans.IsCorrectAnswer = (ans.Id == answerId));
        }

        public override bool GradeQuestion()
        {
            string correctAnswer = possibleAnswers.Where(ans => ans.IsCorrectAnswer).Select(ans => ans.Text).Single();
            return SelectedAnswers.Select(ans => ans.Text).Single() == correctAnswer;
        }
    }
}
