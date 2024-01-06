using System;

namespace Data {
    [Serializable]
    public class LootData {
        public int Collected;
        public Action ChangedAction;

        public void Collect(Loot loot){
            Collected += loot.Value;
           ChangedAction?.Invoke();
        }
    }
}
