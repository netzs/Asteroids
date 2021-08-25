namespace Asteroid.GameLogic
{
    public class DestroyAsteroidSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.spaceObject.RemoveObjectPool)
            {
                if (item.Value is AsteroidData ad && ad.sizeIndex + 1 < Config.asteroids.Length)
                {
                    SpaceModel.AddAsteroid(ad.sizeIndex + 1, item.Value.position);
                    SpaceModel.AddAsteroid(ad.sizeIndex + 1, item.Value.position);
                }
            }
        }
    }
}