using System;
using UnityEngine;

namespace Asteroid.GameLogic
{
    public class PlayerControllerSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            var player = SpaceModel.playerData;
            player.rotation = Quaternion.Euler(0f, 0f,
                player.rotation.eulerAngles.z - player.Input.x * Config.playerConfig.angleSpeed * deltaTime);
            if (player.Input.y > 0)
            {
                player.Acceleration = Math.Min(player.Acceleration + deltaTime / Config.playerConfig.accelerationTime,
                    1f);
            }
            else
            {
                player.Acceleration = Math.Max(player.Acceleration - deltaTime / Config.playerConfig.accelerationSlow,
                    0f);
            }

            player.velocity = player.rotation * Vector3.up * (player.Config.speed * player.Acceleration);
        }
    }
}