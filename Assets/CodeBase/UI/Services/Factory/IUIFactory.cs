using Infrastructure.Services;
using Infrastructure.Services.Persistent;

namespace UI.Services.Factory {
    public interface IUIFactory : IService {
        void CreateShop( );
        void CreateRoot();
    }
}