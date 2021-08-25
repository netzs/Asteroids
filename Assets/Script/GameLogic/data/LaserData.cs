using UnityEngine;

namespace Asteroid.GameLogic
{
    public class LaserData : ILaserData
    {
        public Vector2 pos;
        public Vector2 direction;
        public Quaternion rotation;
        public float time;

        public Vector2 Pos => pos;
        public Vector2 Direction => direction;
        public Quaternion Rotation => rotation;
        public float Time => time;
    }

    public interface ILaserData
    {
        public Vector2 Pos { get; }
        public Vector2 Direction { get; }
        public Quaternion Rotation { get; }
        public float Time { get; }
    }
}