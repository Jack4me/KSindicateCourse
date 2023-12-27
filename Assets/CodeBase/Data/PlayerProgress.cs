using System;

namespace Data {
    [Serializable]
    public class PlayerProgress {
        public StateHp stateHeroHp;
        public WorldData worldData;

        public PlayerProgress(string InitialLevel){
            worldData = new WorldData(InitialLevel);
            stateHeroHp = new StateHp();
        } 
    }
}