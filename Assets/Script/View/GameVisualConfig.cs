using UnityEngine;

namespace Asteroid.View
{
    [CreateAssetMenu(menuName = "createGameVisual")]
    public class GameVisualConfig : ScriptableObject
    {
        public GameObject[] asteroids;
        public GameObject bullet;
        public GameObject ufo;
        public GameObject player;
        public GameObject laser;
    }
}