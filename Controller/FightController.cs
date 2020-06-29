using EscapeGame.DAO;
using EscapeGame.Model;
using EscapeGame.View;
using System;

namespace EscapeGame.Controller {
    public class FightController {
        private PlayerController playerController;
        private FightView fightView;
        private OpponentController opponentController;
        private QuestionController questionController;
        public FightController(PlayerController pl) {
            playerController = pl;
            fightView = new FightView();
            questionController = new QuestionController();
            opponentController = new OpponentController();
        }

        public bool StartFight(int level, bool isBoss) {
            Question question;
            opponentController.generateNewOpponent(level, isBoss);
            while(playerController.Player.Health > 0 && opponentController.Opponent.Health > 0) {
                question = questionController.GetRandomQuestion();
                fightView.printFight(0, question, playerController.Player, opponentController.Opponent);
                performAttack(question.ProperAnswer == chooseAnswer(question));
            }

            return playerController.Player.Health > 0;
        }

        private int chooseAnswer(Question question) {
            int playerAnswer = 0;
            ConsoleKey key;
            while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Enter)) {
                switch (key) {
                    case ConsoleKey.LeftArrow:
                        if (playerAnswer != 1 && playerAnswer != 3) continue;
                        playerAnswer--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (playerAnswer != 0 && playerAnswer != 2) continue;
                        playerAnswer++;    
                        break;
                    case ConsoleKey.UpArrow:
                        if (playerAnswer != 2 && playerAnswer != 3) continue;
                        playerAnswer -= 2;
                        break;
                    case ConsoleKey.DownArrow:
                        if (playerAnswer != 0 && playerAnswer != 1) continue;
                        playerAnswer += 2;
                        break;
                }
                fightView.printFight(playerAnswer, question, playerController.Player, opponentController.Opponent);
            }
            return playerAnswer;
        }


        private void performAttack(bool isPlayerAttack) {
            int defence, attack, damage;
            if (isPlayerAttack) {
                defence = opponentController.Opponent.Defence;
                attack = playerController.GenerateAttack();
                damage = opponentController.ReceiveDamage(attack);
            } else {
                defence = playerController.Player.Defence;
                attack = opponentController.GenerateAttack();
                damage = playerController.ReceiveDamage(attack);
            }
            fightView.PrintResult(isPlayerAttack, attack, defence, damage);
        }

    }
}
