﻿using System;

namespace UI.Services {
    public class WindowService : IWindowService {
        public readonly IUIFactory _uiFactory;

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