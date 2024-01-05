using System;

namespace Data {
    [Serializable]
    public class WorldData {
        public LootData LootData;
        public PositionAtLvL positionAtLvL;

        public WorldData(string initialLevel){
            positionAtLvL = new PositionAtLvL(initialLevel);
        }
    }
}