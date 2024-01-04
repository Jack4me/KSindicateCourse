﻿using UnityEngine;

namespace StaticData {
    [CreateAssetMenu(fileName = "MonsterData", menuName = "StaticData/Monster")]
    public class MonsterStaticData : ScriptableObject {

        public MonsterTypeId MonsterEnumId;  
        [Range(1, 100)]
        public int Hp;
        [Range(1, 30)]
        public int Damage;
        [Range(1, 2)]
        public int Cleavage;
        [Range(1, 3)]
        public int EffectiveDistance;
        public int MoveSpeed;
        public GameObject Prefab;
        
    }
}