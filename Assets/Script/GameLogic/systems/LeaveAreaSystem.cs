using System.Collections.Generic;

namespace Asteroid.GameLogic
{
    public class LeaveAreaSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            var rmKey = new List<int>();
            foreach (var it in SpaceModel.spaceObject.Objects)
            {
                var p = it.Value;
                if (p.position.x + p.Config.radius < -0.5f * Config.boardWidth ||
                    p.position.x - p.Config.radius > 0.5f * Config.boardWidth ||
                    p.position.y + p.Config.radius < -0.5f * Config.boardHeight ||
                    p.position.y - p.Config.radius > 0.5f * Config.boardHeight)
                {
                    rmKey.Add(it.Key);
                }
            }

            foreach (var id in rmKey)
            {
                SpaceModel.spaceObject.Del(id);
            }
        }
    }
}