using System;

namespace EscapeGame.Model {
    public class Question {
        public string QuestionText { get; set; }
        public int ProperAnswer { get; set; }
        public string[] Answers { get; set; }

        public Question(string questionText, string[] answers, int properAnswer ) {
            QuestionText = questionText;
            if(answers.Length != 4 || properAnswer > 3 || properAnswer < 0) {
                throw new ArgumentException();
            }

            Answers = answers;
            ProperAnswer = properAnswer;
        }
    }
}
