using Infrastructure.Services;

namespace UI.Services {
    public interface IWindowService : IService {
        void OpenWindow(WindowIdEnum windowIdEnum);
    }
}