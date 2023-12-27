using System;

namespace Data {
    [Serializable]
    public class WorldData {
        public PositionAtLvL positionAtLvL;

        public WorldData(string InitialLevel){
            positionAtLvL = new PositionAtLvL(InitialLevel);
        }
    }
}