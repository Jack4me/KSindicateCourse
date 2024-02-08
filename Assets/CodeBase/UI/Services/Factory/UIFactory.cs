using Infrastructure.AssetsManagement;
using StaticData;
using UI.Services.Windows;
using UnityEngine;

namespace UI.Services.Factory {
    class UIFactory : IUIFactory {
        private const string UI_ROOT = "UI/UI_Root";
        public readonly IInstantiateProvider _assets;
        public IStaticDataService _staticData;
        private Transform _uiRoot;

        public UIFactory(IInstantiateProvider assets, IStaticDataService staticData){
            _assets = assets;
            _staticData = staticData;
        }

        public void CreateShop(){
            WindowConfig shop = _staticData.ForWindow(WindowIdEnum.Shop);
            Object.Instantiate(shop.Prefab, _uiRoot);
        }

        public void CreateRoot(){
            _uiRoot = _assets.Instantiate(UI_ROOT).transform;
        }
    }
}