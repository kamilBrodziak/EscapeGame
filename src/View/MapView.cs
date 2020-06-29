using EscapeGame.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EscapeGame.View {
    public class MapView {
        public void RenderMap(int playerPosX, int playerPosY, int radius, in List<List<ChunkType>> mapChunks) {
            Console.Clear();
            string[] mapView = mapChunks.Select(i => String.Join("", i.Select(j => (char)j))).ToArray();
            char[] line = mapView[playerPosY].ToCharArray();
            line[playerPosX] = (char)ChunkType.Player;
            mapView[playerPosY] = new string(line);
            int lineXStart = Math.Max(0, playerPosX - radius),
                lineXLength = Math.Min(mapView[0].Length, 4 *  radius),
                lineYStart = Math.Max(0, playerPosY - radius),
                lineYLength = Math.Min(mapView.Length, playerPosY + radius);
            for (int i = lineYStart; i < lineYLength; ++i) {
                Console.WriteLine(mapView[i].Substring(lineXStart, lineXLength));
            }
        }
    }
}