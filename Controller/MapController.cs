using System.Collections.Generic;

namespace EscapeGame {
    class MapController {
        public List<List<ChunkType>> MapChunks { get; set; }
        private MapView mapView;
        public int Level { get; set; }

        public MapController(int level) {
            mapView = new MapView();
            LoadMap(level);
        }

        public bool IsFreeChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Floor);
        }

        public bool IsItemBoxChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Itembox);
        }

        public bool IsOpponentChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Opponnent);
        }

        public bool IsGateChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Gate);
        }

        public bool IsBossChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Boss);
        }

        public void LoadMap(int level) {
            MapChunks = MapDao.LoadMap(level);
        }
        
        public void nextLevel() {
            Level++;
        }

        public void RenderMap(Player player) {
            mapView.RenderMap(player.PosX, player.PosY, player.Visibility, MapChunks);
        }

        public ChunkType GetChunk(int x, int y) {
            return MapChunks[y][x];
        }

        public void SetChunk(int x, int y, ChunkType chunk) {
            MapChunks[y][x] = chunk;
        }
    }
}
