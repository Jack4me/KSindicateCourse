using System;
using Unity.VisualScripting;
using UnityEngine;

namespace StaticData {
[Serializable]
    public class EnemySpawnerData {
        public string Id;
        public MonsterTypeId MosterTypeId;
        public Vector3 Position;
    }
}