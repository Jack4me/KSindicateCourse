using UI.Services.Factory;
using UnityEngine;

namespace UI.Services.Windows {
    public class WindowService : IWindowService {
        public readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory){
            _uiFactory = uiFactory;
        }
        public void OpenWindow(WindowIdEnum windowIdEnum){
            
MonoBehaviour.print("ERROR");
            switch (windowIdEnum){
                case WindowIdEnum.Unknown:
                    break;
                case WindowIdEnum.Shop:
                    _uiFactory.CreateShop();
                    break;
                
            }
        }
    }
}