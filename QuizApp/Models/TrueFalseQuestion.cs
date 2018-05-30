using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public class TrueFalseQuestion : MultipleChoiceQuestion
    {
        private List<Answer> possibleAnswers = new List<Answer>();
        public override string Text { get; set; }
        public override IReadOnlyCollection<Answer> PossibleAnswers
        {
            get {return possibleAnswers.AsReadOnly();}
        }

        public TrueFalseQuestion()
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

        public override bool GradeQuestion(List<Answer> selectedAnswers)
        {
            throw new NotImplementedException();
        }
    }
}
