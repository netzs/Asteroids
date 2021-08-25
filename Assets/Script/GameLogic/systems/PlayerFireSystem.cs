using UnityEngine;

namespace Asteroid.GameLogic
{
    public class PlayerFireSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            SpaceModel.playerData.bulletTime -= deltaTime;
            if (SpaceModel.playerData.bulletTime < 0)
            {
                SpaceModel.playerData.bulletTime += Config.playerConfig.bulletDelay;

                SpaceModel.AddBullet(SpaceModel.playerData.position, SpaceModel.playerData.rotation * Vector3.up);
            }
        }
    }
}