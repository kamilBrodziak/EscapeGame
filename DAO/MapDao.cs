using EscapeGame.Model;
using System.Collections.Generic;
using System.IO;

namespace EscapeGame.DAO {
    class MapDao {

        public static List<List<ChunkType>> LoadMap(int level) {
            StreamReader mapReader = new StreamReader("files/map" + level + ".txt");
            var mapChunks = new List<List<ChunkType>>();
            string line;
            while ((line = mapReader.ReadLine()) != null) {
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
                mapChunks.Add(chunksLine);
            }
            return mapChunks;
        }
    }
}
