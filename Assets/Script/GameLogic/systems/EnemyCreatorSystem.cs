using UnityEngine;

namespace Asteroid.GameLogic
{
    public class EnemyCreatorSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.AsteroidSpawnData)
            {
                var obj = SpaceObjectFactory.CreateAsteroid(item.size);
                obj.position = item.isRandomPos ? GetRandomPos() : item.position;
                SpaceModel.spaceObject.Add(obj);
            }

            for (var i = 0; i < SpaceModel.NewUfoCount; i++)
            {
                var obj = SpaceObjectFactory.CreateUfo();
                obj.position = GetRandomPos();
                SpaceModel.spaceObject.Add(obj);
            }
        }

        private Vector2 GetRandomPos()
        {
            while (true)
            {
                var pos = new Vector2(Random.Range(-0.5f * Config.boardWidth, 0.5f * Config.boardWidth),
                    Random.Range(-0.5f * Config.boardHeight, 0.5f * Config.boardHeight));

                if ((pos - SpaceModel.playerData.position).sqrMagnitude < 10 * 10) continue;
                return pos;
            }
        }
    }
}