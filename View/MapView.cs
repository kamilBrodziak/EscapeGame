using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame {
    public class MapView {
        public void RenderMap(int playerPosX, int playerPosY, int radius, List<List<ChunkType>> mapChunks) {
            Console.Clear();
            for(int i = Math.Max(0, playerPosY - radius); i < Math.Min(mapChunks.Count, playerPosY + radius); ++i) {
                for(int j = Math.Max(0, playerPosX - 2 * radius); 
                    j < Math.Min(mapChunks[i].Count, playerPosX + 2 * radius); ++j) {
                    if(i == playerPosY && j == playerPosX) {
                        Console.Write((char)ChunkType.Player);
                    } else {
                        Console.Write((char)mapChunks[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}