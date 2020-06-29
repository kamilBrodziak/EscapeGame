using EscapeGame.Model;
using System;
namespace EscapeGame.View {
    class FightView {
        public void PrintFight(int playerAnswer, Question question, Player player, Opponent opponent) {
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
                PrintAnswers(whichAnswer, question.Answers[0], question.Answers[1]);
                Console.WriteLine();
                PrintAnswers(0, question.Answers[2], question.Answers[3]);
            } else {
                int whichAnswer = playerAnswer == 2 ? 1 : 2;
                PrintAnswers(0, question.Answers[0], question.Answers[1]);
                Console.WriteLine();
                PrintAnswers(whichAnswer, question.Answers[2], question.Answers[3]);
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            PrintAnswers(0, $"Your health: {player.Health}", $"Opponent health: {opponent.Health}");
        }

        private void PrintAnswers(int playerAnswer, string answer1, string answer2) {
            int answer1BoxLength = 45, answer2BoxLength = 45;
            string answer1Border = "█", answer2Border = "█";
            if(playerAnswer == 1)
                answer1Border = "██████";
            else if(playerAnswer == 2)
                answer2Border = "██████";

            int answer1LeftTextLength = (int)Math.Floor((answer1BoxLength - answer1.Length) / 2.0) - answer1Border.Length,
                answer1RightTextLength = (int)Math.Ceiling((answer1BoxLength - answer1.Length) / 2.0) - answer1Border.Length,
                answer2LeftTextLength = (int)Math.Floor((answer2BoxLength - answer2.Length) / 2.0) - answer2Border.Length,
                answer2RightTextLength = (int)Math.Ceiling((answer2BoxLength - answer2.Length) / 2.0) - answer2Border.Length;

            Console.WriteLine($"{new String('█', answer1BoxLength)}{new String(' ', 10)}{new String('█', answer2BoxLength)}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1BoxLength - 2 * answer1Border.Length)}{answer1Border}" + 
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2BoxLength - 2 * answer2Border.Length)}{answer2Border}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1LeftTextLength)}" +
                $"{answer1}{new String(' ', answer1RightTextLength)}{answer1Border}" +
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2LeftTextLength)}" +
                $"{answer2}{new String(' ', answer2RightTextLength)}{answer2Border}");
            Console.WriteLine($"{answer1Border}{new String(' ', answer1BoxLength - 2 * answer1Border.Length)}{answer1Border}" +
                $"{new String(' ', 10)}{answer2Border}{new String(' ', answer2BoxLength - 2 * answer2Border.Length)}{answer2Border}");
            Console.WriteLine($"{new String('█', answer1BoxLength)}{new String(' ', 10)}{new String('█', answer2BoxLength)}");
        }

        public void PrintResult(bool isPlayerWin) {
            if(isPlayerWin) {
                Console.WriteLine("You won! Check what item you got!");
            } else {
                Console.WriteLine("You lost! Come back later.");
            }
            System.Threading.Thread.Sleep(4000);
        }
   
        public void PrintStrikeResult(bool isPlayerAttack, int attack, int defense, int damage) {
            if (isPlayerAttack) {
                Console.WriteLine("Correct answer! You attacked opponent.");
                Console.WriteLine($"You have {attack} attack points and opponent has {defense} defense points.");
                Console.WriteLine($"Your opponent received {damage} damage");
            } else {
                Console.WriteLine("Wrong answer! Opponent attacked you.");
                Console.WriteLine($"Opponent has {attack} attack points and you have {defense} defense points.");
                Console.WriteLine($"You received {damage} damage");
            }
            System.Threading.Thread.Sleep(4000);
        }
    }

    
}
