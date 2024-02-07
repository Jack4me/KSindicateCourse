using Infrastructure.Services;
using UI.Services.Windows;

namespace UI.Services {
    public interface IWindowService : IService {
        void OpenWindow(WindowIdEnum windowIdEnum);
    }
}