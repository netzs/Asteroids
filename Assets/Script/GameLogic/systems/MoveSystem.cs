namespace Asteroid.GameLogic
{
    public class MoveSystem : SpaceSystem
    {
        public override void Run(float deltaTime)
        {
            foreach (var item in SpaceModel.spaceObject.Objects)
            {
                item.Value.position += item.Value.velocity * deltaTime;
            }

            var pos = SpaceModel.playerData.position + SpaceModel.playerData.velocity * deltaTime;
            if (pos.x < -0.5 * Config.boardWidth)
            {
                pos.x += Config.boardWidth;
            }
            else if (pos.x > 0.5 * Config.boardWidth)
            {
                pos.x -= Config.boardWidth;
            }

            if (pos.y < -0.5 * Config.boardHeight)
            {
                pos.y += Config.boardHeight;
            }
            else if (pos.y > 0.5 * Config.boardHeight)
            {
                pos.y -= Config.boardHeight;
            }

            SpaceModel.playerData.position = pos;
        }
    }
}