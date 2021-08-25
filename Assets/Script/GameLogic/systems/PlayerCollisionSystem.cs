namespace Asteroid.GameLogic
{
    public class PlayerCollisionSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            var player = SpaceModel.playerData;
            foreach (var item in SpaceModel.spaceObject.Objects)
            {
                if (!(item.Value is BulletData))
                {
                    var enemy = item.Value;
                    if ((player.position - enemy.position).sqrMagnitude <
                        (player.Config.radius + enemy.Config.radius) * (player.Config.radius + enemy.Config.radius))
                    {
                        SpaceModel.state = GameState.GameOver;
                        break;
                    }
                }
            }
        }
    }
}