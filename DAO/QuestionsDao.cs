using EscapeGame.Model;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame.DAO {
    class QuestionsDao {

        public static List<Question> LoadQuestions() {
            List <Question> questions = new List<Question>();
            StreamReader sr = new StreamReader("files/questions.txt");
            string line;

            while ((line = sr.ReadLine()) != null) {
                string[] properties = line.Split(';');
                string questionText = properties[0];
                int properAnswer = int.Parse(properties[1]);
                string[] answers = properties[2].Split(',');
                questions.Add(new Question(questionText, answers, properAnswer));
            }
            return questions;
        }
    }
}
