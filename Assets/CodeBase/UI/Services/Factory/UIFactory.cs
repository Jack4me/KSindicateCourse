using Infrastructure.AssetsManagement;
using Infrastructure.Services.Persistent;
using StaticData;
using StaticData.Windows;
using UI.Services.Windows;
using UI.Windows;
using UnityEngine;

namespace UI.Services.Factory {
    class UIFactory : IUIFactory {
        private const string UI_ROOT = "UI/UI_Root";
        public readonly IInstantiateProvider _assets;
        public IStaticDataService _staticData;
        
        private readonly IPersistentProgressService _progress;
        private Transform _uiRoot;

        public UIFactory(IInstantiateProvider assets, IStaticDataService staticData,
            IPersistentProgressService progress){
            _assets = assets;
            _staticData = staticData;
            _progress = progress;
        }

        public void CreateShop(){
            WindowConfig shop = _staticData.ForWindow(WindowIdEnum.Shop);
            WindowBase window = Object.Instantiate(shop.Prefab, _uiRoot);
            window.Construct(_progress);
        }

        public void CreateRoot(){
            _uiRoot = _assets.Instantiate(UI_ROOT).transform;
        }
    }
}