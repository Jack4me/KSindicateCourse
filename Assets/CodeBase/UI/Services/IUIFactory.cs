using Infrastructure.Services;

namespace UI.Services {
    public interface IUIFactory : IService {
        void CreateShop();
        void CreateRoot();
    }
}