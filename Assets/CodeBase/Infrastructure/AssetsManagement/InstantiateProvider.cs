using UnityEngine;

namespace Infrastructure.AssetsManagement {
    public class InstantiateProvider : IInstantiateProvider {
        public GameObject Instantiate(string Path){
            GameObject prefab = Resources.Load<GameObject>(Path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string Path, Vector3 At){
            GameObject prefab = Resources.Load<GameObject>(Path);
            return Object.Instantiate(prefab, At, Quaternion.identity);
        }
    }
}