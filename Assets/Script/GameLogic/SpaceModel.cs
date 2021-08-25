using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.GameLogic
{
    public class SpaceModel : ISpaceModel
    {
        public GameState state;
        public PlayerData playerData;

        public readonly List<AsteroidCreateData> AsteroidSpawnData = new List<AsteroidCreateData>();
        public readonly Pool<SpaceObjectData> spaceObject = new Pool<SpaceObjectData>();
        public readonly List<BulletCreateData> BulletSpawnData = new List<BulletCreateData>();

        public int NewUfoCount;

        public void Reset()
        {
            EndTick();
            spaceObject.Reset();
            playerData.Reset();
        }

        public void AddAsteroid(int size)
        {
            AsteroidSpawnData.Add(new AsteroidCreateData {size = size, isRandomPos = true});
        }

        public void AddAsteroid(int size, Vector2 pos)
        {
            AsteroidSpawnData.Add(new AsteroidCreateData {size = size, position = pos, isRandomPos = false});
        }

        public void AddUfoCount()
        {
            NewUfoCount++;
        }

        public void EndTick()
        {
            NewUfoCount = 0;
            AsteroidSpawnData.Clear();
            BulletSpawnData.Clear();
        }

        public void AddBullet(Vector2 playerPosition, Vector2 playerVelocity)
        {
            BulletSpawnData.Add(new BulletCreateData {pos = playerPosition, dir = playerVelocity});
        }

        public GameState State => state;
        public IPlayerData PlayerData => playerData;
        public AbstractPoolObject<SpaceObjectData> SpaceObject => spaceObject;
    }

    public interface ISpaceModel
    {
        public GameState State { get; }
        public IPlayerData PlayerData { get; }
        public AbstractPoolObject<SpaceObjectData> SpaceObject { get; }
    }
}