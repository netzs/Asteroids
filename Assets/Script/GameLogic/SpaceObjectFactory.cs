using UnityEngine;

namespace Asteroid.GameLogic
{
    public class SpaceObjectFactory
    {
        private readonly GameLogicConfig _logicConfig;

        public SpaceObjectFactory(GameLogicConfig logicConfig)
        {
            _logicConfig = logicConfig;
        }

        public AsteroidData CreateAsteroid(int size)
        {
            var item = new AsteroidData {Config = _logicConfig.asteroids[size], sizeIndex = size};
            item.velocity = GetRandomDirection() * item.Config.speed;
            return item;
        }

        private Vector2 GetRandomDirection()
        {
            var dir =
                new Vector2(Random.Range(-0.5f * _logicConfig.boardWidth, 0.5f * _logicConfig.boardWidth),
                    Random.Range(-0.5f * _logicConfig.boardHeight, 0.5f * _logicConfig.boardHeight)
                );
            if (dir == Vector2.zero) dir = Vector2.down;
            dir.Normalize();
            return dir;
        }


        public UfoData CreateUfo()
        {
            var item = new UfoData {Config = _logicConfig.ufo};
            return item;
        }

        public BulletData CreateBullet()
        {
            var item = new BulletData {Config = _logicConfig.bullet};
            return item;
        }
    }
}