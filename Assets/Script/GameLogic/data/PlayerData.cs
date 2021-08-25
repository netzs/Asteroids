using UnityEngine;

namespace Asteroid.GameLogic
{
    public class PlayerData : SpaceObjectData, IPlayerData
    {
        public float Acceleration;
        public Quaternion rotation;
        public Vector2 Input;
        public float bulletTime;
        public bool isLaser;
        public int laserCount;
        public float laserTimeRestore;
        public LaserData laser;
        public int score;

        public void Reset()
        {
            position = Vector2.zero;
            velocity = Vector2.zero;
            Acceleration = 0;
            rotation = Quaternion.identity;
            Input = Vector2.zero;
            bulletTime = 0;
            isLaser = false;
            laserCount = 0;
            laserTimeRestore = 0;
            laser = null;
            score = 0;
        }

        public Vector2 Position => position;
        public Vector2 Velocity => velocity;
        public Quaternion Rotation => rotation;
        public float BulletTime => bulletTime;
        public bool IsLaser => isLaser;
        public int LaserCount => laserCount;
        public float LaserTimeRestore => laserTimeRestore;
        public ILaserData Laser => laser;
        public int Score => score;
    }

    public interface IPlayerData
    {
        public Vector2 Position { get; }
        public Vector2 Velocity { get; }
        public Quaternion Rotation { get; }
        public float BulletTime { get; }
        public bool IsLaser { get; }
        public int LaserCount { get; }
        public float LaserTimeRestore { get; }
        public ILaserData Laser { get; }
        public int Score { get; }
    }
}