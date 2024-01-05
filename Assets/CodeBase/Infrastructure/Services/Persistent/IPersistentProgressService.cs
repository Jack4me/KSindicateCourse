using Data;

namespace Infrastructure.Services.Persistent {
    public interface IPersistentProgressService : IService {
        PlayerProgress Progress{ get; set; }
        
        
        
    }
    
}