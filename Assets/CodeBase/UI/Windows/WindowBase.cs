using System;
using Data;
using Infrastructure.Services.Persistent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows {
    public class WindowBase : MonoBehaviour {
        public Button CloseButton;
        protected IPersistentProgressService ProgressService;

        protected PlayerProgress PlayerProgress{
            get{ return ProgressService.Progress; }
        }

        public void Construct(IPersistentProgressService progressService){
            ProgressService = progressService;
        }

        private void Awake() => OnAwake();

        protected virtual void OnAwake() => CloseButton.onClick.AddListener(() => Destroy(gameObject));
       
        private void Start(){
            Initialize();
            SubscribeUpdate();
        }

        private void OnDestroy(){
            CleanUp();
        }


        protected virtual void Initialize(){
        }

        protected virtual void SubscribeUpdate(){
        }

        protected virtual void CleanUp(){
        }
    }
}