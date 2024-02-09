using UI.Services;
using UI.Services.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Elements {
    public class OpenWindowButton : MonoBehaviour {
        public Button ButtonOpen;
        public WindowIdEnum WindowIdEnum;
        private IWindowService _windowService;

        public void Construct(IWindowService windowService){
            _windowService = windowService;
            if (_windowService!=null){
                MonoBehaviour.print("ERROR");

            }
        }

        private void Awake(){
            ButtonOpen.onClick.AddListener(Open);
        }

        private void Open(){
             _windowService.OpenWindow(WindowIdEnum);
        }
        
    }
}