using System;

namespace Data {
    [Serializable]
    public class WorldData {
        public LootData LootData;
        public PositionAtLvL PositionAtLvL;

        public WorldData(string initialLevel){
            LootData = new LootData();
            PositionAtLvL = new PositionAtLvL(initialLevel);
        }
    }
}