using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame {
    public class Map {
        public List<List<ChunkType>> MapChunks { get; set; } 
        public Map(int whichMap) {
            LoadMap(whichMap);
        }

        public bool isFreeChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Floor);
        }

        public void LoadMap(int whichMap) {
            StreamReader mapReader = new StreamReader("map" + whichMap + ".txt");
            MapChunks = new List<List<ChunkType>>();
            string line;
            while((line = mapReader.ReadLine() ) != null) {
                List<ChunkType> chunksLine = new List<ChunkType>();
                foreach (char c in line) {
                    switch (c) {
                        case 'O':
                            chunksLine.Add(ChunkType.Opponnent);
                            break;
                        case 'B':
                            chunksLine.Add(ChunkType.Boss);
                            break;
                        case '$':
                            chunksLine.Add(ChunkType.Itembox);
                            break;
                        case '█':
                            chunksLine.Add(ChunkType.Wall);
                            break;
                        case 'G':
                            chunksLine.Add(ChunkType.Gate);
                            break;
                        case ' ':
                            chunksLine.Add(ChunkType.Floor);
                            break;
                    }
                }
                MapChunks.Add(chunksLine);
            }
        }

        public ChunkType GetChunk(int x, int y) {
            return MapChunks[y][x];
        }

        public void SetChunk(int x, int y, ChunkType chunk) {
            MapChunks[y][x] = chunk;
        }

        public void RenderMap(int playerPosX, int playerPosY, int radius) {
            Console.Clear();
            for(int i = Math.Max(0, playerPosY - radius); i < Math.Min(MapChunks.Count, playerPosY + radius); ++i) {
                for(int j = Math.Max(0, playerPosX - 2 * radius); 
                    j < Math.Min(MapChunks[i].Count, playerPosX + 2 * radius); ++j) {
                    if(i == playerPosY && j == playerPosX) {
                        Console.Write((char)ChunkType.Player);
                    } else {
                        Console.Write((char)MapChunks[i][j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}