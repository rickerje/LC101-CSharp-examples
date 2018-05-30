using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Models
{
    public abstract class Question
    {        
        public abstract string Text { get; set; }
        public abstract IReadOnlyCollection<Answer> PossibleAnswers { get; protected set; }

        public abstract void AddAnswer(Answer answer);
        public abstract void RemoveAnswer(Answer answer);
        public abstract bool GradeQuestion(List<Answer> selectedAnswers);
        
    }

    public class Answer
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrectAnswer { get; set; }

        public override bool Equals(object obj)
        {
            Answer answer = obj as Answer;
            if (answer != null)
                return false;
            else
                return answer.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
