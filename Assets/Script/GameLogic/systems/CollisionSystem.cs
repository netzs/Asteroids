namespace Asteroid.GameLogic
{
    public class CollisionSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.spaceObject.Objects)
            {
                var isBreak = false;
                if (item.Value is BulletData bulletData)
                {
                    foreach (var it in SpaceModel.spaceObject.Objects)
                    {
                        if (!(it.Value is BulletData))
                        {
                            var enemy = it.Value;
                            if ((bulletData.position - enemy.position).sqrMagnitude <
                                Sq(bulletData.Config.radius + enemy.Config.radius))
                            {
                                isBreak = true;
                                SpaceModel.spaceObject.Del(item.Key);
                                SpaceModel.spaceObject.Del(it.Key);
                                SpaceModel.playerData.score += it.Value.Config.score;

                                break;
                            }
                        }
                    }
                }

                if (isBreak) break;
            }
        }

        private static float Sq(float a)
        {
            return a * a;
        }
    }
}