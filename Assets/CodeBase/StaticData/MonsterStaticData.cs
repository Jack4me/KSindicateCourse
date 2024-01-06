using UnityEngine;

namespace StaticData {
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject {
        public MonsterTypeId MonsterEnumId;
        public int MaxLoot;
        public int MinLoot;
        [Range(1, 100)] public int Hp;
        [Range(1, 30)] public int Damage;
        [Range(1, 7)] public int Radius;
        [Range(1, 7)] public int EffectiveDistance;
        public int MoveSpeed;
        public GameObject Prefab;
    }
}