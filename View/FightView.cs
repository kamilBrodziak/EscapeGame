using EscapeGame.Model;
using System;
namespace EscapeGame.View {
    class FightView {
        public void printFight(int playerAnswer, Question question, Player player, Opponent opponent) {
            Console.Clear();
            Console.WriteLine(new String('█', 100));

            Console.WriteLine($"█{new String(' ', 98)}█");
            Console.WriteLine($"█{new String(' ', (int)Math.Floor((98 - question.QuestionText.Length)/2.0))}{question.QuestionText}{new String(' ', (int)Math.Ceiling((98 - question.QuestionText.Length) / 2.0))}█");
            Console.WriteLine($"█{new String(' ', 98)}█");
            Console.WriteLine(new String('█', 100));
            Console.WriteLine();
            Console.WriteLine();
            if (playerAnswer < 2) {
                int whichAnswer = playerAnswer == 0 ? 1 : 2;
                printAnswers(whichAnswer, question.Answers[0], question.Answers[1]);
                Console.WriteLine();
                printAnswers(0, question.Answers[2], question.Answers[3]);
            } else {
                int whichAnswer = playerAnswer == 2 ? 1 : 2;
                printAnswers(0, question.Answers[0], question.Answers[1]);
                Console.WriteLine();
                printAnswers(whichAnswer, question.Answers[2], question.Answers[3]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            printAnswers(0, $"Your health: {player.Health}", $"Opponent health: {opponent.Health}");
        }

        private void printAnswers(int playerAnswer, string answer1, string answer2) {
            int answer1BoxLength = 43, answer2BoxLength = 43;
            string answer1Border = "█", answer2Border = "█";
            if(playerAnswer == 1) {
                answer1BoxLength = 39;
                answer1Border = "███";
            } else if(playerAnswer == 2) {
                answer2BoxLength = 39;
                answer2Border = "███";
            }
            int answer1LeftTextLength = (int)Math.Floor((answer1BoxLength - answer1.Length) / 2.0),
                answer1RightTextLength = (int)Math.Ceiling((answer1BoxLength - answer1.Length) / 2.0),
                answer2LeftTextLength = (int)Math.Floor((answer2BoxLength - answer2.Length) / 2.0),
                answer2RightTextLength = (int)Math.Ceiling((answer2BoxLength - answer2.Length) / 2.0);

            Console.WriteLine($"{new String('█', 45)}{new String(' ', 10)}{new String('█', 45)}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1BoxLength)}{answer1Border}" + 
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2BoxLength)}{answer2Border}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1LeftTextLength)}" +
                $"{answer1}{new String(' ', answer1RightTextLength)}{answer1Border}" +
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2LeftTextLength)}" +
                $"{answer2}{new String(' ', answer2RightTextLength)}{answer2Border}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1BoxLength)}{answer1Border}" +
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2BoxLength)}{answer2Border}");
            Console.WriteLine($"{new String('█', 45)}{new String(' ', 10)}{new String('█', 45)}");
        }
   
        public void PrintResult(bool isPlayerAttack, int attack, int defense, int damage) {
            if (isPlayerAttack) {
                Console.WriteLine("Correct answer! You attacked opponent.");
                Console.WriteLine($"You have {attack} attack points and opponent has {defense} defense points.");
                Console.WriteLine($"Your opponent received {damage} damage");
            } else {
                Console.WriteLine("Wrong answer! Opponent attacked you.");
                Console.WriteLine($"Opponent has {attack} attack points and you have {defense} defense points.");
                Console.WriteLine($"You received {damage} damage");
            }
        }
    }

    
}
