using EscapeGame.DAO;
using EscapeGame.Model;
using EscapeGame.View;
using System;
using System.Collections.Generic;

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
            ConsoleKey key;
            int playerAnswer = 0;
            bool printFight = false;
            opponentController.generateNewOpponent(level, isBoss);
            while(playerController.Player.Health > 0 && opponentController.Opponent.Health > 0) {
                playerAnswer = 0;
                Question question = questionController.GetRandomQuestion();
                fightView.printFight(playerAnswer, question, playerController.Player, opponentController.Opponent);
                while (!(key = Console.ReadKey().Key).Equals(ConsoleKey.Enter)) {
                    printFight = false;
                    switch(key) {
                        case ConsoleKey.LeftArrow:
                            if(playerAnswer == 1 || playerAnswer == 3) {
                                playerAnswer--;
                                printFight = true;
                            }
                            break;
                        case ConsoleKey.RightArrow:
                            if (playerAnswer == 0 || playerAnswer == 2) {
                                playerAnswer++;
                                printFight = true;
                            }
                            break;
                        case ConsoleKey.UpArrow:
                            if (playerAnswer == 2 || playerAnswer == 3) {
                                playerAnswer-=2;
                                printFight = true;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (playerAnswer == 0 || playerAnswer == 1) {
                                playerAnswer += 2;
                                printFight = true;
                            }
                            break;
                    }

                    if(printFight) {
                        fightView.printFight(playerAnswer, question, playerController.Player, opponentController.Opponent);
                    }
                }
                int defence, attack, damage;
                if (question.ProperAnswer == playerAnswer) {
                    defence = opponentController.Opponent.Defence;
                    attack = playerController.GenerateAttack();
                    damage = opponentController.ReceiveDamage(attack);
                } else {
                    defence = playerController.Player.Defence;
                    attack = opponentController.GenerateAttack();
                    damage = playerController.ReceiveDamage(attack);
                }
                fightView.PrintResult(question.ProperAnswer == playerAnswer, attack, defence, damage);
                System.Threading.Thread.Sleep(4000);
            }

            return playerController.Player.Health > 0;
        }


    }
}
