using System;
using UI.Services;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Elements {
    public class OpenWindowButton : MonoBehaviour {
        public Button WindowOpen;
        public WindowIdEnum WindowIdEnum;
        private IWindowService _windowService;

        public void Construct(IWindowService windowService){
            _windowService = windowService;
            
        }

        private void Awake(){
            WindowOpen.onClick.AddListener(Open);
        }

        private void Open(){
            _windowService.OpenWindow(WindowIdEnum);
        }
    }
}