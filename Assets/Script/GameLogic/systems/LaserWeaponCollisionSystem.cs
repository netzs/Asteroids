using System.Collections.Generic;
using UnityEngine;

namespace Asteroid.GameLogic
{
    public class LaserWeaponCollisionSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            if (SpaceModel.playerData.laser != null)
            {
                SpaceModel.playerData.laser.time -= deltaTime;
                if (SpaceModel.playerData.laser.time < 0)
                {
                    SpaceModel.playerData.laser = null;
                }
                else
                {
                    var rmKey = new List<int>();
                    foreach (var it in SpaceModel.spaceObject.Objects)
                    {
                        if (!(it.Value is BulletData))
                        {
                            var enemy = it.Value;
                            Vector3.Project(enemy.position, SpaceModel.playerData.laser.direction);
                            var enNorm = enemy.position - SpaceModel.playerData.laser.pos;
                            var tt = (Vector2) Vector3.Project(enNorm, SpaceModel.playerData.laser.direction);
                            if ((enNorm - tt).sqrMagnitude < it.Value.Config.radius * it.Value.Config.radius +
                                Config.laserWidth * Config.laserWidth &&
                                (tt.normalized + SpaceModel.playerData.laser.direction.normalized).sqrMagnitude > 1f)
                            {
                                rmKey.Add(it.Key);
                                SpaceModel.playerData.score += it.Value.Config.score;
                            }
                        }
                    }

                    foreach (var id in rmKey)
                    {
                        SpaceModel.spaceObject.Del(id);
                    }
                }
            }
        }
    }
}