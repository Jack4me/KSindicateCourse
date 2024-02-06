using System;
using UnityEngine;

namespace Infrastructure.Services {
    public class GameRunner : MonoBehaviour {
        public GameBootstrapper bootstrapper;

        private void Awake(){
            GameBootstrapper bootstrapper = FindObjectOfType<GameBootstrapper>();
            if (bootstrapper == null){
                Instantiate(this.bootstrapper);
            }
        }
    }
}