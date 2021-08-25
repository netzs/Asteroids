using System;
using UnityEngine;

namespace Asteroid.GameLogic
{
    [CreateAssetMenu(menuName = "createGameLogic")]
    public class GameLogicConfig : ScriptableObject
    {
        public float boardWidth;
        public float boardHeight;

        public float timeAsteroidRespawn;
        public float minTimeTick;

        public SpaceObjectConfig[] asteroids;
        public SpaceObjectConfig ufo;
        public float timeUfoRespawn;

        public PlayerConfig playerConfig;

        public SpaceObjectConfig bullet;
        public float laserTime;
        public float laserWidth;
        public float laserRestoreTime;
    }

    [Serializable]
    public class PlayerConfig : SpaceObjectConfig
    {
        public float angleSpeed;
        public float accelerationTime;
        public float accelerationSlow;
        public float bulletDelay;
    }

    [Serializable]
    public class SpaceObjectConfig
    {
        public float radius;
        public float speed;
        public int score;
    }
}