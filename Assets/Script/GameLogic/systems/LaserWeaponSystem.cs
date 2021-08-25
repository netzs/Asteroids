using UnityEngine;

namespace Asteroid.GameLogic
{
    public class LaserWeaponSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            var player = SpaceModel.playerData;
            if (player.isLaser)
            {
                player.isLaser = false;
                if (player.laserCount > 0)
                {
                    player.laserCount--;

                    player.laser = new LaserData()
                    {
                        pos = player.position, direction = SpaceModel.playerData.rotation * Vector3.up,
                        rotation = SpaceModel.playerData.rotation, time = Config.laserTime
                    };
                }
            }
        }
    }
}