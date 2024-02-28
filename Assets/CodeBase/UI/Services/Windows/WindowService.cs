using UI.Services.Factory;
using UnityEngine;

namespace UI.Services.Windows {
    public class WindowService : IWindowService {
        private readonly IUIFactory _uiFactory;

        public WindowService(IUIFactory uiFactory){
            _uiFactory = uiFactory;
        }
        public void OpenWindow(WindowIdEnum windowIdEnum){
            

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