using Random = UnityEngine.Random;


namespace Infrastructure.Services.Randomizer 

{
    class RandomService : IRandomService {
        public int Next(int min, int max) =>
            Random.Range(min, max);
    }
}