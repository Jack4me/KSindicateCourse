using System;

namespace Data {
    [Serializable]
    public class PlayerProgress {
        public StateHp StateHeroHp;
        public WorldData WorldData;
        public KillData KillData;
        public HeroStats HeroStats;

        public PlayerProgress(string initialLevel){
            WorldData = new WorldData(initialLevel);
            KillData = new KillData();
            StateHeroHp = new StateHp();
            HeroStats = new HeroStats();
        }
    }
}