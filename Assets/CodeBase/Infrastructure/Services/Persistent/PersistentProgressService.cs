using Data;

namespace Infrastructure.Services.Persistent {
    public class PersistentProgressService : IPersistentProgressService {
       public PlayerProgress Progress{ get; set; }
    }
}