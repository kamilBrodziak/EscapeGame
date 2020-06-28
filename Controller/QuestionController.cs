using EscapeGame.DAO;
using EscapeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EscapeGame.Controller {
    class QuestionController {
        private List<Question> questions;

        public QuestionController() {
            questions = QuestionsDao.LoadQuestions();
        }

        public Question GetRandomQuestion() {
            Random rnd = new Random();
            return questions[rnd.Next(0, questions.Count)];
        }

    }
}
