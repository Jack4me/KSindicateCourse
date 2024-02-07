using System;
using UI;
using UI.Services;
using UI.Services.Windows;
using UI.Windows;

namespace StaticData {
    [Serializable]
    public class WindowConfig {
        public WindowIdEnum WindowId;
        public WindowBase Prefab;
    }
    
    
}