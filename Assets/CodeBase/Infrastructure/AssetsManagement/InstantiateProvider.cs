using UnityEngine;

namespace Infrastructure.AssetsManagement {
    public class InstantiateProvider : IInstantiateProvider {
        public GameObject Instantiate(string path){
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Vector3 at){
            GameObject prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, at, Quaternion.identity);
        }
    }
}