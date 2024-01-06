using System;

namespace Data {
    [Serializable]
    public class PlayerProgress {
        public StateHp stateHeroHp;
        public WorldData worldData;
        public KillData KillData;
        public HeroStats HeroStats;

        public PlayerProgress(string initialLevel){
            worldData = new WorldData(initialLevel);
            KillData = new KillData();
            stateHeroHp = new StateHp();
            HeroStats = new HeroStats();
        }
    }
}