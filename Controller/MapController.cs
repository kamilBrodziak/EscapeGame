using System.Collections.Generic;

namespace EscapeGame {
    class MapController {
        public List<List<ChunkType>> MapChunks { get; set; }
        private MapView mapView;
        public int Level { get; set; }

        public MapController() {
            mapView = new MapView();
            Level = 1;
            LoadMap();
        }

        public bool IsFreeChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Floor);
        }

        public bool IsItemBoxChunk(int x, int y) {
            return MapChunks[y][x].Equals(ChunkType.Itembox);
        }

        public void LoadMap() {
            MapChunks = MapDao.LoadMap(Level);
        }
        
        public void nextLevel() {
            Level++;
        }

        public void RenderMap(Player player) {
            mapView.RenderMap(player.PosX, player.PosY, player.Inventory.GetLightStat(), MapChunks);
        }

        public ChunkType GetChunk(int x, int y) {
            return MapChunks[y][x];
        }

        public void SetChunk(int x, int y, ChunkType chunk) {
            MapChunks[y][x] = chunk;
        }
    }
}
