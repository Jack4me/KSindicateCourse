using System;
using UI.Services.Windows;
using UI.Windows;

namespace StaticData.Windows {
    [Serializable]
    public class WindowConfigData {
        public WindowIdEnum WindowId;
        public WindowBase Prefab;
    }
}