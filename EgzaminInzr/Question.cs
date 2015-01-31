using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminInzr
{
    public enum Answer
    {
        Unknown,A,B,C
    }
    class Question
    {
        public int ID { get; set; }
        public Answer Answer { get; set; }
        public string QuestionText { get; set; }
        public List<String> Answers { get; set; }
        public Question(int id, string question,List<String> answers)
        {
            ID = id;
            Answers = answers;
            Answer = EgzaminInzr.Answer.Unknown;
            QuestionText = question;
        }
        public Question(int id)
        {
            ID = id;
        }
        public Question(int id, string question, string answerA,string answerB,string answerC)
        {
            ID = id;
            Answers = new List<string>();
            Answers.Add(answerA);
            Answers.Add(answerB);
            Answers.Add(answerC);
            Answer = EgzaminInzr.Answer.Unknown;
            QuestionText = question;
        }
    }
}
