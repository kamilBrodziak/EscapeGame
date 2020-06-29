# EscapeGame

Project made from scratch in 3 days (24 hours);
Project made for studies task.

This project is a console escape game with 3 levels.
Each level has a different map and different gate (to another level) mini game.
Map is represented by .txt file.
In most of the times player can interact only by pressing keys.
All rules are described below and in menu tutorial option.

        Hello player!
        When you start the game, map will render.
            
        MAP:
            You can move on map by pressing arrow keys.
            On the map you can find few different chunks.
            █ - wall, you can't pass through it.
            $ - itembox, you can get one item from it.
            O - opponent, when you enter that chunk fight with opponent will begin.
            B - boss, same as opponent, but when you loose - game over, when you win - you will aquire key.
            G - gate to another level. Key is required to pass.
            
        FIGHT:
            Fight with opponent or boss is initialized when you enter O/B chunk.
            Fight is a series of questions. You must choose answer.
            You can choose answer by pressing arrow keys.
            When you choose your answer press Enter.
            If answer was correct you hit enemy.
            If answer was incorrect, enemy hit you.
            If you win a fight, you get one item for fight with opponent, three items and key for fight with boss.
            If you loose a fight, you can start again with opponent, but you loose whole game if you lost a fight with boss.
            You should fight with lots of opponents to get items, otherwise you will easily loose with boss.
            
        INVENTORY:
            You can open and close inventory by pressing I key.
            You can navigate through inventory items by pressing up/down arrow keys.
            If you want to equip some item, select it and press Enter
            
        ITEMS:
            Sword - increase your attack.
            Armor - increase your defence.
            Light - increase your visibility.
            
        GATE, LEVELS:
            If you want to pass to next level, you should have a key.
            Key can be obtained after successful fight with boss.
            There are 3 levels, you start on level 1.
            Next levels have a different map, different mini game, and harder enemies.
            Mini games will start when you try to pass to another level.
            If you want to pass to next level, you must win mini game.
            If you loose, on first two levels nothing happens.
            Last level mini game is special, if you win it, you win game, if you lose - game over.
            
        Good luck!