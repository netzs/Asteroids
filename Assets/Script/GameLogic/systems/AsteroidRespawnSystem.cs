namespace Asteroid.GameLogic
{
    internal class AsteroidRespawnSystem : SpaceSystem
    {
        private float _timeNewAsteroid;
        private float _timeNewUfo;

        public override void Run(float deltaTime)
        {
            _timeNewAsteroid -= deltaTime;
            while (_timeNewAsteroid < 0)
            {
                _timeNewAsteroid += Config.timeAsteroidRespawn;
                SpaceModel.AddAsteroid(0);
            }

            _timeNewUfo -= deltaTime;
            while (_timeNewUfo < 0)
            {
                _timeNewUfo += Config.timeUfoRespawn;
                SpaceModel.AddUfoCount();
            }
        }
    }
}